namespace CodingExercise.Constants
{
    public static class ErrorMessageConstants
    {
        public const string TooManyOrTooFewArgumentsErrorMessage = "Too many or too few arguments were submitted in the command line";
        
        public const string InvalidKeywordArgumentErrorMessage = "One or both of the keywords is null or empty";
        public const string InvalidRangeArgumentErrorMessage = "The numeric range argument is invalid";
        public const string InvalidFileArgumentErrorMessage = "The file could not be found or cannot be read";

        public const string InvalidInputFileIndexErrorMessage = "No word exists at this location in the input file";
        public const string InvalidInputFileRangeErrorMessage = "Range must be an integer greater than the MinimumValidRange";

        public const string InputFileReaderGetRangeWithoutReadingErrorMessage = "Must call ReadUntilNextKeyword at least once before we can get the range";
    }
}