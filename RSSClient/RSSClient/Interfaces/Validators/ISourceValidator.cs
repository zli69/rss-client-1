using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSClient.Interfaces.Validators
{
    /// <summary>
    /// Validates an url given a Key in of the source
    /// </summary>
    public interface ISourceValidator
    {
        /// <summary>
        /// Verify if the source is valid
        /// </summary>
        /// <param name="url">Url given</param>
        /// <returns></returns>
        bool IsValid(KeyValuePair<int, string> url);
        /// <summary>
        /// Verify if the source is valid
        /// </summary>
        /// <param name="url">Url given</param>
        /// <returns></returns>
        bool IsValidArray(Dictionary<int, string> url);
    }
}
