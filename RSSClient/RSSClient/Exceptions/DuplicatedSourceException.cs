using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSClient.Exceptions
{
    /// <summary>
    /// Represent an invalid URL Source Exception
    /// </summary>
    public class DuplicatedSourceException : ApplicationException
    {
        /// <summary>
        /// Message Source
        /// </summary>
        private int source;
      
        /// <summary>
        /// Invalid URL Exception Constructor
        /// </summary>
        /// <param name="sourceId">SourceId</param>
        public DuplicatedSourceException(int sourceId) : base("There are duplicated sources in the provided parameters")
        {
            source = sourceId;
        }

        /// <summary>
        /// Returns the message of the exceptions
        /// </summary>
        public override string Message
        {
            get
            {
                return string.Format("Source {0} - {1}", source.ToString(), base.Message);
            }
        }
    }
}
