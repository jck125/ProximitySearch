namespace CodingExercise.Interfaces
{
    public interface IInputFile
    {
        public string GetWordAtIndex(int index);
        public string[] GetWordsInRange(int startIndex, int range);
        public int GetWordCount();
    }
}