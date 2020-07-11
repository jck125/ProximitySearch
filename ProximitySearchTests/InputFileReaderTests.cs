using System;
using CodingExercise.Constants;
using CodingExercise.Inputfile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProximitySearchTests.Constants;

namespace ProximitySearchTests
{
    [TestClass]
    public class InputFileReaderTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt"));
            
            //If no exception is thrown, this test passes
            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public void TestReadUntilNextKeywordWithValidKeywords()
        {
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt"));

            Assert.AreEqual("the", reader.ReadUntilNextKeyword("the", "canal"));
            Assert.AreEqual("canal", reader.ReadUntilNextKeyword("panama", "canal"));
        }
        
        [TestMethod]
        public void TestReadUntilNextKeywordWithBlankKeyword()
        {
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt"));

            try
            {
                reader.ReadUntilNextKeyword("", "canal");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(ErrorMessageConstants.InvalidKeywordArgumentErrorMessage, e.Message);
            }
        }
        
        [TestMethod]
        public void TestReadUntilNextKeywordWithNullKeyword()
        {
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt"));

            try
            {
                reader.ReadUntilNextKeyword(null, "canal");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(ErrorMessageConstants.InvalidKeywordArgumentErrorMessage, e.Message);
            }
        }
        
        [TestMethod]
        public void TestReadUntilNextKeywordWithKeywordsThatAreNotInValidTestFile()
        {
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt"));
            
            Assert.AreEqual("", reader.ReadUntilNextKeyword("MissingKeywordOne", "MissingKeywordTwo"));
        }
        
        [TestMethod]
        public void TestGetRangeOfWordsWithValidRange()
        {
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt"));
            
            Assert.AreEqual(2, reader.GetRangeOfWords(2).Length);
            Assert.AreEqual("the", reader.GetRangeOfWords(2)[0]);
            Assert.AreEqual("man", reader.GetRangeOfWords(2)[1]);
        }
    }
}