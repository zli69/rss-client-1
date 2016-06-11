using RSSClient.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSClient.Validators
{
    /// <summary>
    /// Validator implementation for validating URL
    /// </summary>
    /// <author>
    /// Carlos A. Rivera M.
    /// </author>
    public class UrlValidator : ISourceValidator
    {
        /// <summary>
        /// Regular Expression used to verify the Url
        /// </summary>
        private const string UrlRegularExpression = @"^htt(p|ps)://[a-zA-Z\.\/:\-0-9\~]+";
        /// <summary>
        /// Regular Expression object
        /// </summary>
        private Regex regex;

        /// <summary>
        /// Constructor
        /// </summary>
        public UrlValidator()
        {
            regex = new Regex(UrlRegularExpression);
        }

        /// <summary>
        /// Validate a given source
        /// </summary>
        /// <param name="url">Source given</param>
        /// <returns>True if is valid, false otherwise</returns>
        public bool IsValid(KeyValuePair<int, string> url)
        {
            return regex.IsMatch(UrlRegularExpression);
        }
        /// <summary>
        /// List of source givent o validate
        /// </summary>
        /// <param name="url">List of Sources</param>
        /// <returns>True if is valid, false otherwise</returns>
        public bool IsValidArray(Dictionary<int, string> url)
        {
            for(int i = 0; i < url.Count; i++)
            {
                if (!this.IsValid(url.ElementAt(i)))
                    return false;
            }

            return true;
        }
    }
}
