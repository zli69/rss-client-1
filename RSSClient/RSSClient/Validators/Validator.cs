using RSSClient.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSClient.Validators
{
    public class Validator : IValidator
    {
        /// <summary>
        /// Source of the RSS
        /// </summary>
        public Dictionary<int, string> Source
        {
            get;

            set;
        }

        /// <summary>
        /// Validates an RSS source given 
        /// </summary>
        /// <param name="validators"></param>
        /// <returns>True if valid</returns>
        /// <exception cref="DuplicatedSourceException"></exception>
        /// <exception cref="InvalidURLException"></exception>
        public bool Validate(IEnumerable<ISourceValidator> validators)
        {
            bool result = false;

            foreach (var item in validators)
            {
                result = item.IsValidArray(Source);
            }

            return result;
        }
    }
}
