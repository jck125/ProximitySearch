using System;
using System.IO;
using CodingExercise.Inputfile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProximitySearchTests.Constants;

namespace ProximitySearchTests
{
    [TestClass]
    public class InputFileTests
    {
        [TestMethod]
        public void TestConstructorWithValidFile()
        {
            InputFile file = new InputFile(LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt");
            
            //If no exception is thrown, this test passes
            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestConstructorWithInvalidFile()
        {
            InputFile file = new InputFile("FakeTestFile.txt");
        }

        [TestMethod]
        public void TestGetWordsInRangeWithValidRange()
        {
            int testRange = 2;
            int testStartIndex = 0;
            InputFile file = new InputFile(LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt");

            string[] words = file.GetWordsInRange(testStartIndex, testRange);
            Assert.AreEqual(testRange, words.Length);
            Assert.AreEqual("The", words[0]);
            Assert.AreEqual("man", words[1]);
        }
        
        [TestMethod]
        public void TestGetWordsInRangeWithZeroRange()
        {
            int testRange = 0;
            int testStartIndex = 0;
            InputFile file = new InputFile(LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt");

            string[] words = file.GetWordsInRange(testStartIndex, testRange);
            Assert.AreEqual(testRange, words.Length);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetWordsInRangeWithNegativeRange()
        {
            int testRangeInvalid = -1;
            int testStartIndex = 0;
            InputFile file = new InputFile(LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt");

            file.GetWordsInRange(testStartIndex, testRangeInvalid);
        }
    }
}