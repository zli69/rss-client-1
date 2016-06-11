using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSClient.Interfaces
{
    /// <summary>
    /// Interface that represents the RSS client
    /// </summary>
    public interface IRSSClient
    {
        /// <summary>
        /// This method returns the rss feed from the data passed as parameters
        /// </summary>
        /// <author>
        /// Carlos A. Rivera M.
        /// </author>
        /// <date>
        /// 10 Jun 2016
        /// </date>
        /// <param name="sources">
        /// Dictionary that stores a key/value pair containing the Id of the source and the URL
        /// </param>
        /// <returns>
        /// IRSSData depending the version of RSS used.
        /// </returns>
        IEnumerable<IRSSData> GetData(Dictionary<int, string> sources);
    }
}
