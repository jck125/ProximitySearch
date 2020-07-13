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
            InputFileReader reader = InputFileReader.GetReader(this.file);
            
            //Get the first keyword in the file
            string currentWord = reader.ReadUntilNextKeyword(keywordOne, keywordTwo);
            int proximityCount = 0;

            do
            {
                //Calculate the proximity of the range of words from the current position
                proximityCount += CalculateProximity(reader.GetRangeOfWords(range));
                
                //Get the next keyword in the file
                currentWord = reader.ReadUntilNextKeyword(keywordOne, keywordTwo);
            } 
            while (!string.IsNullOrEmpty(currentWord)); //ReadUntilNextKeyword returns an empty string, we have reached the end of the file and can stop looping

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
            int proximity = 0;
            
            //Depending on which keyword this range starts from,
            //we want to get the number of occurences of the other keyword in that range
            if (words[0].Equals(keywordOne))
                proximity = words.Count(word => word.Equals(keywordTwo));
            else if (words[0].Equals(keywordTwo))
                proximity = words.Count(word => word.Equals(keywordOne));

            //If the keywords are the same,
            //we'll have to decrement the proximity by one so we don't double count the first word of the range
            if (keywordOne.Equals(keywordTwo))
                proximity--;

            return proximity;
        }
    }
}