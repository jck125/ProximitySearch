using System;
using System.IO;
using CodingExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProximitySearchTests
{
    [TestClass]
    public class ProximitySearchTests
    {
        private ProximitySearch _proximitySearch;

        [TestMethod]
        public void TestConstructorValidInput()
        {
            string[] args = new[] {"the", "canal", "6", "filename.txt"};
            _proximitySearch = new ProximitySearch(args);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorTooManyArguments()
        {
            string[] args = new[] {"the", "canal", "6", "filename.txt", "additionalArg"};
            _proximitySearch = new ProximitySearch(args);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorTooFewArguments()
        {
            string[] args = new[] {"the", "canal", "6"};
            _proximitySearch = new ProximitySearch(args);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorThirdArgumentNotAnInteger()
        {
            string[] args = new[] {"the", "canal", "six", "filename.txt"};
            _proximitySearch = new ProximitySearch(args);
        }
        
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestConstructorFileNotFound()
        {
            string[] args = new[] {"the", "canal", "6", "nonexistentfile.txt"};
            _proximitySearch = new ProximitySearch(args);
        }
    }
}