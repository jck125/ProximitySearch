using System;
using CodingExercise.Constants;
using Microsoft.VisualBasic;

namespace CodingExercise.Inputfile
{
    public class InputFileReader
    {
        private readonly InputFile inputFile;
        private int currentIndex;

        public InputFileReader(InputFile inputFile)
        {
            this.inputFile = inputFile;
            currentIndex = 0;
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

        public string[] GetRangeOfWords(int range)
        {
            if(!ArgumentValidator.ValidateRange(range))
                throw new ArgumentException(ErrorMessageConstants.InvalidKeywordArgumentErrorMessage);

            return inputFile.GetWordsInRange(currentIndex, range);
        }
    }
}