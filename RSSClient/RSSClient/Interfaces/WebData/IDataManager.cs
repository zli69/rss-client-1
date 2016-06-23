using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSClient.Interfaces.WebData
{
    /// <summary>
    /// Interface that describe the methods to obtain the RSS Data
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Given a list of URL retrieves a list of RSS information in string
        /// </summary>
        /// <param name="urls">Parameters URLs</param>
        /// <returns>A list of string that contains the RSS info</returns>
        string[] DownloadRSSData(string[] urls);
    }
}
