using System;
using CodingExercise;
using CodingExercise.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProximitySearchTests.Constants;

namespace ProximitySearchTests
{
    [TestClass]
    public class ProximitySearchTests
    {
        private ProximitySearch _proximitySearch;

        [TestMethod]
        public void TestConstructorValidArguments()
        {
            string[] args = new[] {"the", "canal", "6", LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.Example2FileName};
            _proximitySearch = new ProximitySearch(args);
            
            //If no exception is thrown, this test passes
            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public void TestConstructorTooManyArguments()
        {
            string[] args = new[] {"the", "canal", "6", LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.Example2FileName, "additionalArg"};
            
            try
            {
                _proximitySearch = new ProximitySearch(args);
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
                _proximitySearch = new ProximitySearch(args);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(ErrorMessageConstants.TooManyOrTooFewArgumentsErrorMessage, e.Message);
            }
        }
        
        [TestMethod]
        public void TestSearchExampleTest1Expect3()
        {
            string[] args = new[] {"the", "canal", "6", LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.Example1FileName};
            _proximitySearch = new ProximitySearch(args);
            
            Assert.AreEqual(3, _proximitySearch.Search());
        }
        
        [TestMethod]
        public void TestSearchExampleTest1Expect1()
        {
            string[] args = new[] {"the", "canal", "3", LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.Example1FileName};
            _proximitySearch = new ProximitySearch(args);
            
            Assert.AreEqual(1, _proximitySearch.Search());
        }
        
        [TestMethod]
        public void TestSearchExampleTest2Expect11()
        {
            string[] args = new[] {"the", "canal", "6", LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.Example2FileName};
            _proximitySearch = new ProximitySearch(args);
            
            Assert.AreEqual(11, _proximitySearch.Search());
        }
        
        [TestMethod]
        public void TestSearchNewLineFileExpect3()
        {
            string[] args = new[] {"the", "canal", "6", LocalFilePathConstants.LocalTestFileDirectory + LocalFilePathConstants.NewLinesFileName};
            _proximitySearch = new ProximitySearch(args);
            
            Assert.AreEqual(3, _proximitySearch.Search());
        }
    }
}