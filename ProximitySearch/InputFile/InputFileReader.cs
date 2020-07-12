using System;
using CodingExercise.Constants;

namespace CodingExercise.Inputfile
{
    public class InputFileReader
    {
        private readonly InputFile inputFile;
        private int currentIndex;

        public InputFileReader(InputFile inputFile)
        {
            this.inputFile = inputFile;
            currentIndex = -1;
        }
        
        /// <summary>
        /// Read through the words in the file until we encounter one of the two keywords, then return that word
        /// </summary>
        /// <param name="keywordOne">One of two keywords we are reading for</param>
        /// <param name="keywordTwo">One of two keywords we are reading for</param>
        /// <returns>Returns the keyword that was found or a blank string if we reach the end of the file</returns>
        public string ReadUntilNextKeyword(string keywordOne, string keywordTwo)
        {
            if(!ArgumentValidator.ValidateKeywords(keywordOne, keywordTwo))
                throw new ArgumentException(ErrorMessageConstants.InvalidKeywordArgumentErrorMessage);
            
            //Start reading by looking at the next word
            currentIndex++;
            
            for (; currentIndex < inputFile.GetWordCount(); currentIndex++)
            {
                if (keywordOne.Equals(inputFile.GetWordAtIndex(currentIndex))
                    || keywordTwo.Equals(inputFile.GetWordAtIndex(currentIndex)))
                {
                    return inputFile.GetWordAtIndex(currentIndex);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns a range length list of words starting at the current word and moving forward along the list.
        /// Must call ReadUntilNextKeyword at least once before calling this method
        /// </summary>
        /// <param name="range">The number of words we should return</param>
        /// <returns>Returns a range list of words starting from the current index</returns>
        /// <exception cref="ArgumentException">Throws an exception if range is less than the minimum range value</exception>
        public string[] GetRangeOfWords(int range)
        {
            if(!ArgumentValidator.ValidateRange(range))
                throw new ArgumentException(ErrorMessageConstants.InvalidKeywordArgumentErrorMessage);
            if(currentIndex < 0)
                throw new InvalidOperationException(ErrorMessageConstants.InputFileReaderGetRangeWithoutReadingErrorMessage);

            return inputFile.GetWordsInRange(currentIndex, range);
        }
    }
}