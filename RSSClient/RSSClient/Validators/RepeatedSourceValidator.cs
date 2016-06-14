using RSSClient.Exceptions;
using RSSClient.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSClient.Validators
{
    /// <summary>
    /// Validator implementation for validating that there are no source repeated
    /// </summary>
    /// <author>
    /// Carlos A. Rivera M.
    /// </author>
    public class RepeatedSourceValidator : ISourceValidator
    {
        /// <summary>
        /// This validator is not required and not be in used.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool IsValid(KeyValuePair<int, string> url)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validates is there are repeated Sources in the array
        /// </summary>
        /// <param name="url">Sources</param>
        /// <returns>True if valid / False Otherwise</returns>
        /// <exception cref="DuplicatedSourceException"></exception>
        public bool IsValidArray(Dictionary<int, string> url)
        {
            int repeatedValues = url.GroupBy(x => x.Value).Count();
            int countUrl = url.Count();

            if (countUrl != repeatedValues)
                throw new DuplicatedSourceException(url.GroupBy(x => x.Key).Where(x => x.Count() > 1).Select(x => x.First().Key).FirstOrDefault());

            return true;
        }
    }
}
