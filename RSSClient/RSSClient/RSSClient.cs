using System;
using System.Collections.Generic;
using RSSClient.Interfaces;
using RSSClient.Interfaces.Validators;

namespace RSSClient
{
    /// <summary>
    /// This class represent a RSS Client
    /// </summary>
    public class RSSClient : IRSSClient
    {
        private IEnumerable<ISourceValidator> validators;

        /// <summary>
        /// RSS Client Constructor
        /// </summary>
        /// <param name="validators">Validators</param>
        public RSSClient(IEnumerable<ISourceValidator> validators = null)
        {
            this.validators = validators;
        }

        public IEnumerable<IRSSData> GetData(Dictionary<int, string> sources)
        {
            throw new NotImplementedException();
        }
    }
}
