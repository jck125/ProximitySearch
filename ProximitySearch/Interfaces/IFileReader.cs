namespace CodingExercise.Interfaces
{
    public interface IFileReader
    {
        public string ReadUntilNextKeyword(string keywordOne, string keywordTwo);
        public string[] GetRangeOfWords(int range);
    }
}