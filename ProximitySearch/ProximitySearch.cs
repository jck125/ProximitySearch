using System;
using System.IO;

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
    }
}