using System;
using System.IO;
using CodingExercise.Constants;
using CodingExercise.Inputfile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProximitySearchTests.Constants;

namespace ProximitySearchTests
{
    [TestClass]
    public class InputFileTests
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
        public void TestConstructorWithValidFile()
        {
            InputFile file = InputFile.GetInputFile(TestFileNameContents.Example2FileName);
            
            //If no exception is thrown, this test passes
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestConstructorWithInvalidFile()
        {
            try
            {
                InputFile file = InputFile.GetInputFile(TestFileNameContents.MissingFileName);
            }
            catch (FileNotFoundException e)
            {
                Assert.AreEqual(ErrorMessageConstants.InvalidFileArgumentErrorMessage, e.Message);
            }
        }
        
        [TestMethod]
        public void TestGetWordCount()
        {
            InputFile file = InputFile.GetInputFile(TestFileNameContents.Example2FileName);
            Assert.AreEqual(21, file.GetWordCount());
        }
        
        [TestMethod]
        public void TestGetWordCountWithEmptyFile()
        {
            InputFile file = InputFile.GetInputFile(TestFileNameContents.EmptyFileName);
            Assert.AreEqual(0, file.GetWordCount());
        }

        [TestMethod]
        public void TestGetWordsInRangeWithValidRange()
        {
            int testRange = 2;
            int testStartIndex = 0;
            InputFile file = InputFile.GetInputFile(TestFileNameContents.Example2FileName);

            string[] words = file.GetWordsInRange(testStartIndex, testRange);
            Assert.AreEqual(testRange, words.Length);
            Assert.AreEqual("the", words[0]);
            Assert.AreEqual("man", words[1]);
        }
        
        [TestMethod]
        public void TestGetWordsInRangeWithValidRangeThatExtendsPastEndOfTestFile()
        {
            int testRange = 6;
            int testStartIndex = 19;
            InputFile file = InputFile.GetInputFile(TestFileNameContents.Example2FileName);

            string[] words = file.GetWordsInRange(testStartIndex, testRange);
            Assert.AreEqual(2, words.Length);
            Assert.AreEqual("canal", words[0]);
            Assert.AreEqual("panama", words[1]);
        }

        [TestMethod]
        public void TestGetWordsInRangeWithZeroRange()
        {
            int testRange = 0;
            int testStartIndex = 0;
            InputFile file = InputFile.GetInputFile(TestFileNameContents.Example2FileName);

            try
            {
                file.GetWordsInRange(testStartIndex, testRange);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(ErrorMessageConstants.InvalidInputFileIndexErrorMessage, e.Message);
            }
        }
        
        [TestMethod]
        public void TestGetWordsInRangeWithNegativeRange()
        {
            int testRangeInvalid = -1;
            int testStartIndex = 0;
            InputFile file = InputFile.GetInputFile(TestFileNameContents.Example2FileName);

            try
            {
                file.GetWordsInRange(testStartIndex, testRangeInvalid);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(ErrorMessageConstants.InvalidInputFileIndexErrorMessage, e.Message);
            }
        }
        
        [TestMethod]
        public void TestGetWordsInRangeWithNegativeStartIndex()
        {
            int testRange = 2;
            int testStartIndexInvalid = -1;
            InputFile file = InputFile.GetInputFile(TestFileNameContents.Example2FileName);

            try
            {
                file.GetWordsInRange(testStartIndexInvalid, testRange);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(ErrorMessageConstants.InvalidInputFileIndexErrorMessage, e.Message);
            }
        }
        
        [TestMethod]
        public void TestGetWordsInRangeWithStartIndexGreaterThanNumberOfWordsInInputFile()
        {
            int testRange = 2;
            int testStartIndexInvalid = 5000;
            InputFile file = InputFile.GetInputFile(TestFileNameContents.Example2FileName);

            try
            {
                file.GetWordsInRange(testStartIndexInvalid, testRange);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(ErrorMessageConstants.InvalidInputFileIndexErrorMessage, e.Message);
            }
        }
        
        [TestMethod]
        public void TestGetWordAtIndexWithValidIndex()
        {
            int testIndex = 3;
            InputFile file = InputFile.GetInputFile(TestFileNameContents.Example2FileName);

            Assert.AreEqual("plan", file.GetWordAtIndex(testIndex));
        }
        
        [TestMethod]
        public void TestGetWordAtIndexWithInvalidIndex()
        {
            int testIndex = 3;
            InputFile file = InputFile.GetInputFile(TestFileNameContents.Example2FileName);

            try
            {
                file.GetWordAtIndex(testIndex);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(ErrorMessageConstants.InvalidInputFileIndexErrorMessage, e.Message);
            }
        }

    }
}