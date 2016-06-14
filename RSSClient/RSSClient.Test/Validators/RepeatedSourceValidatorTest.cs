using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSSClient.Exceptions;
using RSSClient.Interfaces.Validators;
using RSSClient.Validators;
using System.Collections.Generic;

namespace RSSClient.Test.Validators
{
    /// <summary>
    /// Validates and URL
    /// </summary>
    [TestClass]
    public class RepeatedSourceValidatorTest
    {
        /// <summary>
        /// Validator object
        /// </summary>
        ISourceValidator validator;

        /// <summary>
        /// Initialices the validator Object
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            validator = new RepeatedSourceValidator();
        }

        /// <summary>
        /// This method test the url validator format with a valid URL Format
        /// </summary>
        [TestMethod]
        public void ValidateSource_UnrepeatedSources_ReturnSuccesfull()
        {
            Dictionary<int, string> sourceArray = new Dictionary<int, string>();
            sourceArray.Add(0, "http://www.google.com");
            sourceArray.Add(1, "http://www.remolacha.net");
            sourceArray.Add(2, "http://www.yahoo.net");

            Assert.IsTrue(validator.IsValidArray(sourceArray));
        }

        /// <summary>
        /// This method test the url validator format with a unvalid URL given the array validator
        /// </summary>
        [TestMethod]
        public void ValidateSource_RepeatedFormatArraySource_ReturnFailure()
        {
            Dictionary<int, string> sourceArray = new Dictionary<int, string>();
            sourceArray.Add(0, "http://www.google.com");
            sourceArray.Add(1, "http://www.google.com");
            sourceArray.Add(2, "http://www.yahoo.net");

            try
            {
                Assert.IsFalse(validator.IsValidArray(sourceArray));
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DuplicatedSourceException));
            }
        }
    }
}
