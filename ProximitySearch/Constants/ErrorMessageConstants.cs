namespace CodingExercise.Constants
{
    public static class ErrorMessageConstants
    {
        public const string InvalidKeywordArgumentErrorMessage = "One or both of the keywords is null or empty";
        public const string InvalidRangeArgumentErrorMessage = "The numeric range argument is invalid";
        public const string InvalidFileArgumentErrorMessage = "The file could not be found or cannot be read";

        public const string InvalidInputFileIndex = "No word exists at this location in the input file";
        public const string InvalidInputFileRange = "Range must be an integer greater than the MinimumValidRange";
    }
}