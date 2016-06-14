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
    public class UrlValidatorTest
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
            validator = new UrlValidator();
        }

        /// <summary>
        /// This method test the url validator format with a valid URL Format
        /// </summary>
        [TestMethod]
        public void ValidateURL_ValidURLFormat_ReturnSuccesfull()
        {
            KeyValuePair<int, string> source = new KeyValuePair<int, string>(0, "http://www.google.com.do");
            Dictionary<int, string> sourceArray = new Dictionary<int, string>();
            sourceArray.Add(0, "http://www.google.com");
            sourceArray.Add(1, "http://www.remolacha.net");
            sourceArray.Add(2, "http://www.yahoo.net");

            try
            {
                Assert.IsTrue(validator.IsValid(source));
                Assert.IsTrue(validator.IsValidArray(sourceArray));
            }
            catch (System.Exception)
            {
                Assert.Fail("Invalid URL given");
            }
        }

        /// <summary>
        /// This method test the url validator format with a unvalid URL given the single validator
        /// </summary>
        [TestMethod]
        public void ValidateURL_WrongURLFormatSingleSource_ReturnFailure()
        {
            KeyValuePair<int, string> source = new KeyValuePair<int, string>(0, "httsp://www.google.com.do");
            Dictionary<int, string> sourceArray = new Dictionary<int, string>();
            sourceArray.Add(0, "http://www.google.com");
            sourceArray.Add(1, "http://www.remolacha.net");
            sourceArray.Add(2, "http://www.yahoo.net");

            try
            {
                Assert.IsFalse(validator.IsValid(source));
                Assert.IsTrue(validator.IsValidArray(sourceArray));
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidURLException));
            }
        }

        /// <summary>
        /// This method test the url validator format with a unvalid URL given the array validator
        /// </summary>
        [TestMethod]
        public void ValidateURL_WrongURLFormatArraySource_ReturnFailure()
        {
            KeyValuePair<int, string> source = new KeyValuePair<int, string>(0, "http://www.google.com.do");
            Dictionary<int, string> sourceArray = new Dictionary<int, string>();
            sourceArray.Add(0, "321http://www.google.com");
            sourceArray.Add(1, "8778");
            sourceArray.Add(2, "http://www.yahoo.net");

            try
            {
                Assert.IsTrue(validator.IsValid(source));
                Assert.IsFalse(validator.IsValidArray(sourceArray));
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidURLException));
            }
        }
    }
}
