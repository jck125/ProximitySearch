using System;
using System.Collections.Generic;
using System.IO;
using CodingExercise.Constants;

namespace CodingExercise.Inputfile
{
    public class InputFile
    {
        private readonly string[] words;
        
        /// <summary>
        /// Constructor accepts the path to the input file and fills the words array with all of the words from the input file.
        /// If the input file cannot be read or does not exist, it returns a FileNotFoundException
        /// </summary>
        /// <param name="filePath">The path to the file to be read</param>
        /// <exception cref="FileNotFoundException">Returns this exception if the file does not exist or cannot be read</exception>
        public InputFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string fileContents = File.ReadAllText(filePath);
                fileContents = fileContents.Replace(Environment.NewLine, InputFileConstants.InputFileWordSeparator);
                words = fileContents.Split(InputFileConstants.InputFileWordSeparator);
            }
            else
                throw new FileNotFoundException(ErrorMessageConstants.InvalidFileArgumentErrorMessage);
        }
        
        /// <summary>
        /// Returns an array which which contains the words from the words array starting at startIndex and moving
        /// forward for distance range. If the range extends past the end of the words array, method returns an array
        /// with all of the words from the words array from startIndex to the end of the words array
        /// </summary>
        /// <param name="startIndex">The index of the first word we want returned from the words array</param>
        /// <param name="range">The number of total words we want returned from the words array</param>
        /// <returns>Returns an array of strings from the words array starting at startIndex and moving forward for distance range</returns>
        /// <exception cref="ArgumentException">Throws this exception if the startIndex or range are invalid</exception>
        public string[] GetWordsInRange(int startIndex, int range)
        {
            if(!ValidateIndex(startIndex))
                throw new ArgumentException(ErrorMessageConstants.InvalidInputFileIndex);
            if(!ValidateRange(range))
                throw new ArgumentException(ErrorMessageConstants.InvalidInputFileRange);

            List<string> subArray = new List<string>();
            int currentIndex = startIndex;

            for (int i = 0; i < range; i++)
            {
                if (currentIndex < words.Length)
                {
                    subArray.Add(words[currentIndex]);
                    currentIndex++;
                }
                else 
                    break;
            }

            return subArray.ToArray();
        }

        /// <summary>
        /// Returns the word at the given index in words
        /// </summary>
        /// <param name="index">The index in words that we want to get the return value from</param>
        /// <returns>A word in words at index index</returns>
        /// <exception cref="ArgumentException">Will throw this exception if index is not a valid index for words</exception>
        public string GetWordAtIndex(int index)
        {
            if(!ValidateIndex(index))
                throw new ArgumentException(ErrorMessageConstants.InvalidInputFileIndex);

            return words[index];
        }

        /// <summary>
        /// Validates the index argument and returns true if it is a valid index in the words array and false if it is not.
        /// </summary>
        /// <param name="index">index to be validated, must be a valid index in the words array</param>
        /// <returns>Returns true if the index is valid for the words array, otherwise returns false</returns>
        private bool ValidateIndex(int index)
        {
            return (index >= 0 && index < words.Length);
        }
        
        /// <summary>
        /// Validates the range argument and returns true if it is an integer greater than or equal to 0, otherwise returns false.
        /// </summary>
        /// <param name="range">range to be validated, must be greater than or equal to 0</param>
        /// <returns>Returns true if the range is greater than 0, otherwise returns false</returns>
        private bool ValidateRange(int range)
        {
            return (range >= 0);
        }
    }
}