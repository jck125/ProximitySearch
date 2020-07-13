using System;
using System.IO;
using CodingExercise;
using CodingExercise.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProximitySearchTests.Constants;

namespace ProximitySearchTests
{
    [TestClass]
    public class ArgumentValidatorTests
    {
        private string TestFilePath;
        
        [TestInitialize]
        public void Initialize()
        {
            TestFilePath = AppDomain.CurrentDomain.BaseDirectory;
            File.WriteAllText(TestFilePath + TestFileNameContents.Example1FileName, TestFileContents.Example1Contents);
            File.WriteAllText(TestFilePath + TestFileNameContents.Example2FileName, TestFileContents.Example2Contents);
            File.WriteAllText(TestFilePath + TestFileNameContents.NewLinesFileName, TestFileContents.NewLineTestContents);
            File.WriteAllText(TestFilePath + TestFileNameContents.EmptyFileName, string.Empty);
        }

        [TestCleanup]
        public void CleanUp()
        {
            File.Delete(TestFilePath + TestFileNameContents.Example1FileName);
            File.Delete(TestFilePath + TestFileNameContents.Example2FileName);
            File.Delete(TestFilePath + TestFileNameContents.NewLinesFileName);
            File.Delete(TestFilePath + TestFileNameContents.EmptyFileName);
        }

        [TestMethod]
        public void TestValidateArgumentsWithValidArguments()
        {
            Assert.IsTrue(ArgumentValidator.ValidateArguments("keywordOne", "keywordTwo", 
                "6", TestFileNameContents.Example2FileName, out string errorMessage));
        }
        
        [TestMethod]
        public void TestValidateArgumentsWhereFirstKeywordIsEmpty()
        {
            bool invalidArgumentsExpectFalse = ArgumentValidator.ValidateArguments(string.Empty, "keywordTwo", 
                "6", TestFileNameContents.Example2FileName, out string errorMessage);

            Assert.AreEqual(errorMessage, ErrorMessageConstants.InvalidKeywordArgumentErrorMessage);
            Assert.IsFalse(invalidArgumentsExpectFalse);
        }
        
        [TestMethod]
        public void TestValidateArgumentsWhereSecondKeywordIsEmpty()
        {
            bool invalidArgumentsExpectFalse = ArgumentValidator.ValidateArguments("keywordOne", string.Empty, 
                "6", TestFileNameContents.Example2FileName, out string errorMessage);

            Assert.AreEqual(errorMessage, ErrorMessageConstants.InvalidKeywordArgumentErrorMessage);
            Assert.IsFalse(invalidArgumentsExpectFalse);
        }
        
        [TestMethod]
        public void TestValidateArgumentsWhereBothKeywordIsEmpty()
        {
            bool invalidArgumentsExpectFalse = ArgumentValidator.ValidateArguments(string.Empty, string.Empty, 
                "6", TestFileNameContents.Example2FileName, out string errorMessage);

            Assert.AreEqual(errorMessage, ErrorMessageConstants.InvalidKeywordArgumentErrorMessage);
            Assert.IsFalse(invalidArgumentsExpectFalse);
        }
        
        [TestMethod]
        public void TestValidateArgumentsWithInvalidRange()
        {
            bool invalidArgumentsExpectFalse = ArgumentValidator.ValidateArguments("keywordOne", "keywordTwo", 
                "NotAnInteger", TestFileNameContents.Example2FileName, out string errorMessage);

            Assert.AreEqual(errorMessage, ErrorMessageConstants.InvalidRangeArgumentErrorMessage);
            Assert.IsFalse(invalidArgumentsExpectFalse);
        }
        
        [TestMethod]
        public void TestValidateArgumentsWithNonexistentFile()
        {
            bool invalidArgumentsExpectFalse = ArgumentValidator.ValidateArguments("keywordOne", "keywordTwo", 
                "6", TestFileNameContents.MissingFileName, out string errorMessage);

            Assert.AreEqual(errorMessage, ErrorMessageConstants.InvalidFileArgumentErrorMessage);
            Assert.IsFalse(invalidArgumentsExpectFalse);
        }
        
        [TestMethod]
        public void TestValidateKeywordsWithValidKeywords()
        {
            Assert.IsTrue(ArgumentValidator.ValidateKeywords("ValidKeywordOne", "ValidKeywordTwo"));
        }
        
        [TestMethod]
        public void TestValidateKeywordsWithTheFirstKeywordInvalid()
        {
            Assert.IsFalse(ArgumentValidator.ValidateKeywords("", "ValidKeywordTwo"));
        }
        
        [TestMethod]
        public void TestValidateKeywordsWithTheSecondKeywordInvalid()
        {
            Assert.IsFalse(ArgumentValidator.ValidateKeywords("ValidKeywordOne", ""));
        }
        
        [TestMethod]
        public void TestValidateKeywordsWithBothKeywordsInvalid()
        {
            Assert.IsFalse(ArgumentValidator.ValidateKeywords("", ""));
        }
        
        [TestMethod]
        public void TestValidateStringRangeWithValidRange()
        {
            Assert.IsTrue(ArgumentValidator.ValidateRange("6"));
        }
        
        [TestMethod]
        public void TestValidateStringRangeWithNonIntegerString()
        {
            Assert.IsFalse(ArgumentValidator.ValidateRange("six"));
        }
        
        [TestMethod]
        public void TestValidateStringRangeWithIntegerStringLessThanMinimumRange()
        {
            Assert.IsFalse(ArgumentValidator.ValidateRange("0"));
        }
        
        [TestMethod]
        public void TestValidateIntRangeWithValidInteger()
        {
            Assert.IsTrue(ArgumentValidator.ValidateRange(6));
        }
        
        [TestMethod]
        public void TestValidateIntRangeWithIntegerLessThanMinimumRange()
        {
            Assert.IsFalse(ArgumentValidator.ValidateRange(0));
        }
        
        [TestMethod]
        public void TestValidateFileWithValidFile()
        {
            Assert.IsTrue(ArgumentValidator.ValidateFile(TestFileNameContents.Example2FileName));
        }
        
        [TestMethod]
        public void TestValidateFileWithMissingFile()
        {
            Assert.IsFalse(ArgumentValidator.ValidateFile(TestFileNameContents.MissingFileName));
        }
        
        [TestMethod]
        public void TestValidateFileWithBlankString()
        {
            Assert.IsFalse(ArgumentValidator.ValidateFile(string.Empty));
        }
        
        [TestMethod]
        public void TestValidateFileWithNullString()
        {
            Assert.IsFalse(ArgumentValidator.ValidateFile(null));
        }
    }
}