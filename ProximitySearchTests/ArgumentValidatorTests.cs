using CodingExercise;
using CodingExercise.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProximitySearchTests.Constants;

namespace ProximitySearchTests
{
    [TestClass]
    public class ArgumentValidatorTests
    {
        [TestMethod]
        public void TestValidateArgumentsWithValidArguments()
        {
            Assert.IsTrue(ArgumentValidator.ValidateArguments("keywordOne", "keywordTwo", 
                "6", LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt", out string errorMessage));
        }
        
        [TestMethod]
        public void TestValidateArgumentsWhereFirstKeywordIsEmpty()
        {
            bool invalidArgumentsExpectFalse = ArgumentValidator.ValidateArguments(string.Empty, "keywordTwo", 
                "6", LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt", out string errorMessage);

            Assert.AreEqual(errorMessage, ErrorMessageConstants.InvalidKeywordArgumentErrorMessage);
            Assert.IsFalse(invalidArgumentsExpectFalse);
        }
        
        [TestMethod]
        public void TestValidateArgumentsWhereSecondKeywordIsEmpty()
        {
            bool invalidArgumentsExpectFalse = ArgumentValidator.ValidateArguments("keywordOne", string.Empty, 
                "6", LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt", out string errorMessage);

            Assert.AreEqual(errorMessage, ErrorMessageConstants.InvalidKeywordArgumentErrorMessage);
            Assert.IsFalse(invalidArgumentsExpectFalse);
        }
        
        [TestMethod]
        public void TestValidateArgumentsWhereBothKeywordIsEmpty()
        {
            bool invalidArgumentsExpectFalse = ArgumentValidator.ValidateArguments(string.Empty, string.Empty, 
                "6", LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt", out string errorMessage);

            Assert.AreEqual(errorMessage, ErrorMessageConstants.InvalidKeywordArgumentErrorMessage);
            Assert.IsFalse(invalidArgumentsExpectFalse);
        }
        
        [TestMethod]
        public void TestValidateArgumentsWithInvalidRange()
        {
            bool invalidArgumentsExpectFalse = ArgumentValidator.ValidateArguments("keywordOne", "keywordTwo", 
                "NotAnInteger", LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt", out string errorMessage);

            Assert.AreEqual(errorMessage, ErrorMessageConstants.InvalidRangeArgumentErrorMessage);
            Assert.IsFalse(invalidArgumentsExpectFalse);
        }
        
        [TestMethod]
        public void TestValidateArgumentsWithNonexistentFile()
        {
            bool invalidArgumentsExpectFalse = ArgumentValidator.ValidateArguments("keywordOne", "keywordTwo", 
                "6", "FakeTestFile.txt", out string errorMessage);

            Assert.AreEqual(errorMessage, ErrorMessageConstants.InvalidFileArgumentErrorMessage);
            Assert.IsFalse(invalidArgumentsExpectFalse);
        }
    }
}