using System;
using System.Linq;
using CodingExercise.Inputfile;

namespace CodingExercise
{
    public class ProximitySearch
    {
        private readonly string keywordOne;
        private readonly string keywordTwo;
        private readonly int range;
        private readonly string file;
        
        public ProximitySearch(string[] args)
        {
            if(args.Length != 4)
                throw new ArgumentException("Too many or too few arguments were submitted in the command line");
            
            if (ArgumentValidator.ValidateArguments(args[0], args[1], args[2], args[3], out string errorMessage))
            {
                this.keywordOne = args[0];
                this.keywordTwo = args[1];
                this.range = int.Parse(args[2]);
                this.file = args[3];
            }
            else
            {
                throw new ArgumentException(errorMessage);
            }
        }

        /// <summary>
        /// Main search method, initializes the reader and loops from keyword to keyword
        /// in the InputFile while keeping track of the proximityCount
        /// </summary>
        public int Search()
        {
            InputFileReader reader = new InputFileReader(new InputFile(this.file));
            string currentWord = reader.ReadUntilNextKeyword(keywordOne, keywordTwo);
            int proximityCount = 0;

            do
            {
                proximityCount += CalculateProximity(reader.GetRangeOfWords(range));
                currentWord = reader.ReadUntilNextKeyword(keywordOne, keywordTwo);
            } 
            while (currentWord.Length != 0);

            return proximityCount;
        }

        /// <summary>
        /// Given a list of words, checks to see if the first word is either of the two keywords. If so,
        /// return the number of occurences of the opposite keyword
        /// </summary>
        /// <param name="words">List of words to search</param>
        /// <returns>Returns the number of times the first word in the list is a keyword the other keyword also exists in the list</returns>
        private int CalculateProximity(string[] words)
        {
            if (words[0].Equals(keywordOne))
            {
                return words.Count(word => word.Equals(keywordTwo));
            }
            else if (words[0].Equals(keywordTwo))
            {
                return words.Count(word => word.Equals(keywordOne));
            }

            return 0;
        }
    }
}