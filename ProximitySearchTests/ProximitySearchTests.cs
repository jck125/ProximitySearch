using System;
using System.IO;
using CodingExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProximitySearchTests.Constants;

namespace ProximitySearchTests
{
    [TestClass]
    public class ProximitySearchTests
    {
        private ProximitySearch _proximitySearch;

        [TestMethod]
        public void TestConstructorValidInput()
        {
            string[] args = new[] {"the", "canal", "6", LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt"};
            _proximitySearch = new ProximitySearch(args);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorTooManyArguments()
        {
            string[] args = new[] {"the", "canal", "6", LocalFilePathConstants.LocalTestFileDirectory + "ValidTestFile.txt", "additionalArg"};
            _proximitySearch = new ProximitySearch(args);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorTooFewArguments()
        {
            string[] args = new[] {"the", "canal", "6"};
            _proximitySearch = new ProximitySearch(args);
        }
    }
}