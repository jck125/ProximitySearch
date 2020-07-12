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
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.Example2FileName));
            
            //If no exception is thrown, this test passes
            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public void TestReadUntilNextKeywordWithValidKeywords()
        {
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.Example2FileName));

            Assert.AreEqual("the", reader.ReadUntilNextKeyword("the", "canal"));
            Assert.AreEqual("canal", reader.ReadUntilNextKeyword("panama", "canal"));
        }
        
        [TestMethod]
        public void TestReadUntilNextKeywordWithBlankKeyword()
        {
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.Example2FileName));

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
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.Example2FileName));

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
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.Example2FileName));
            
            Assert.AreEqual("", reader.ReadUntilNextKeyword("MissingKeywordOne", "MissingKeywordTwo"));
        }
        
        [TestMethod]
        public void TestGetRangeOfWordsWithValidRange()
        {
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.Example2FileName));
            //Have to read before we can get the range of words
            reader.ReadUntilNextKeyword("the", "man");
            
            Assert.AreEqual(2, reader.GetRangeOfWords(2).Length);
            Assert.AreEqual("the", reader.GetRangeOfWords(2)[0]);
            Assert.AreEqual("man", reader.GetRangeOfWords(2)[1]);
        }
        
        [TestMethod]
        public void TestGetRangeOfWordsWithoutReading()
        {
            InputFileReader reader = new InputFileReader(new InputFile(LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.Example2FileName));

            try
            {
                reader.GetRangeOfWords(2);
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(ErrorMessageConstants.InputFileReaderGetRangeWithoutReadingErrorMessage, e.Message);
            }
        }
    }
}