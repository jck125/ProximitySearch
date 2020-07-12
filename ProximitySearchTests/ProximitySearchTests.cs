using System;
using System.IO;
using CodingExercise;
using CodingExercise.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProximitySearchTests.Constants;

namespace ProximitySearchTests
{
    [TestClass]
    public class ProximitySearchTests
    {
        private ProximitySearch proximitySearch;
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
        public void TestConstructorValidArguments()
        {
            string[] args = new[] {"the", "canal", "6", TestFileNameContents.Example2FileName};
            proximitySearch = new ProximitySearch(args);
            
            //If no exception is thrown, this test passes
            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public void TestConstructorTooManyArguments()
        {
            string[] args = new[] {"the", "canal", "6", TestFileNameContents.Example2FileName, "additionalArg"};
            
            try
            {
                proximitySearch = new ProximitySearch(args);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(ErrorMessageConstants.TooManyOrTooFewArgumentsErrorMessage, e.Message);
            }
        }
        
        [TestMethod]
        public void TestConstructorTooFewArguments()
        {
            string[] args = new[] {"the", "canal", "6"};

            try
            {
                proximitySearch = new ProximitySearch(args);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(ErrorMessageConstants.TooManyOrTooFewArgumentsErrorMessage, e.Message);
            }
        }
        
        [TestMethod]
        public void TestSearchExampleTest1Expect3()
        {
            string[] args = new[] {"the", "canal", "6", TestFileNameContents.Example1FileName};
            proximitySearch = new ProximitySearch(args);
            
            Assert.AreEqual(3, proximitySearch.Search());
        }
        
        [TestMethod]
        public void TestSearchExampleTest1Expect1()
        {
            string[] args = new[] {"the", "canal", "3", TestFileNameContents.Example1FileName};
            proximitySearch = new ProximitySearch(args);
            
            Assert.AreEqual(1, proximitySearch.Search());
        }
        
        [TestMethod]
        public void TestSearchExampleTest2Expect11()
        {
            string[] args = new[] {"the", "canal", "6", TestFileNameContents.Example2FileName};
            proximitySearch = new ProximitySearch(args);
            
            Assert.AreEqual(11, proximitySearch.Search());
        }
        
        [TestMethod]
        public void TestSearchNewLineFileExpect3()
        {
            string[] args = new[] {"the", "canal", "6", TestFileNameContents.NewLinesFileName};
            proximitySearch = new ProximitySearch(args);
            
            Assert.AreEqual(3, proximitySearch.Search());
        }
    }
}