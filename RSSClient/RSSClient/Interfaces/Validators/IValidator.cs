using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSClient.Interfaces.Validators
{
    public interface IValidator
    {
        /// <summary>
        /// Source of the validators
        /// </summary>
        Dictionary<int, string> Source { get; set; }
        /// <summary>
        /// Validates an RSS source given 
        /// </summary>
        /// <param name="validators"></param>
        /// <returns>True if valid</returns>
        /// <exception cref="DuplicatedSourceException"></exception>
        /// <exception cref="InvalidURLException"></exception>
        bool Validate(IEnumerable<ISourceValidator> validators);
    }
}
