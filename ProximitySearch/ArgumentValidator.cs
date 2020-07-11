using System.IO;
using CodingExercise.Constants;

namespace CodingExercise
{
    public static class ArgumentValidator
    {
        /// <summary>
        /// Validates the 4 arguments accepted from the command line
        /// </summary>
        /// <param name="keywordOneArg">The first keyword to be validated</param>
        /// <param name="keywordTwoArg">The second keyword to be validated</param>
        /// <param name="rangeArg">The range argument to be validated</param>
        /// <param name="fileArg">The file name argument to be validated</param>
        /// <param name="errorMessage">The output error message if any of the arguments are invalid</param>
        /// <returns>Returns true if all arguments are valid, otherwise returns false and errorMessage will contain a message about the invalid argument</returns>
        public static bool ValidateArguments(string keywordOneArg, string keywordTwoArg, string rangeArg, string fileArg,
            out string errorMessage)
        {
            errorMessage = string.Empty;
            
            if (!ValidateKeywords(keywordOneArg, keywordTwoArg))
            {
                errorMessage = ErrorMessageConstants.InvalidKeywordArgumentErrorMessage;
                return false;
            } 
            
            if (!ValidateRange(rangeArg))
            {
                errorMessage = ErrorMessageConstants.InvalidRangeArgumentErrorMessage;
                return false;
            }
            
            if (!ValidateFile(fileArg))
            {
                errorMessage = ErrorMessageConstants.InvalidFileArgumentErrorMessage;
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// Validate that the keyword arguments are strings that are not null or empty
        /// </summary>
        /// <param name="firstKeyword">The first keyword argument to be validated</param>
        /// <param name="secondKeyword">The second keyword argument to be validated</param>
        /// <returns>Returns true if either of the keywords are not null or empty</returns>
        private static bool ValidateKeywords(string firstKeyword, string secondKeyword)
        {
            return !string.IsNullOrEmpty(firstKeyword) && !string.IsNullOrEmpty(secondKeyword);
        }
        
        /// <summary>
        /// Validate the argument that should contain the integer range value
        /// </summary>
        /// <param name="rangeArgument">The string argument that should contain the integer range value</param>
        /// <returns>Returns true if the range is an integer and greater than the MinimumValidRange, otherwise returns false</returns>
        private static bool ValidateRange(string rangeArgument)
        {
            return int.TryParse(rangeArgument, out var convertedRange) && (convertedRange >= ArgumentValidationConstants.MinimumValidRange);
        }

        /// <summary>
        /// Validate that the argument contains a file or a path to a file that exists
        /// </summary>
        /// <param name="fileArg">The file or path to a file to be validated</param>
        /// <returns>Returns true if fileArg contains the name of a file or path to a file that exists and that we have permission to read</returns>
        private static bool ValidateFile(string fileArg)
        {
            //The Exists method also checks if fileArg is null or a zero-length string
            return File.Exists(fileArg);
        }
    }
}