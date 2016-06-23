using System;
using System.Collections.Generic;
using RSSClient.Interfaces;
using RSSClient.Interfaces.Validators;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using RSSClient.Interfaces.WebData;

namespace RSSClient
{
    /// <summary>
    /// This class represent a RSS Client
    /// </summary>
    public class RSSClient : IRSSClient
    {
        private IValidator validator;
        private IEnumerable<ISourceValidator> validatorsSource;
        private IDataManager dataManager;

        /// <summary>
        /// RSS Client Constructor
        /// </summary>
        /// <param name="validators">Validators</param>
        public RSSClient(IValidator validator = null, IEnumerable<ISourceValidator> validatorsSource = null, IDataManager manager = null)
        {
            this.validator = validator;
            this.validatorsSource = validatorsSource;
            this.dataManager = manager;
        }

        public IEnumerable<IRSSData> GetData(Dictionary<int, string> sources)
        {
            string[] rss;
            validator.Source = sources;

            try
            {
                validator.Validate(validatorsSource);
                rss = dataManager.DownloadRSSData(sources.Select(x => x.Value).ToArray());

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
