
using System;

namespace CodingExercise
{
    public class ProximitySearchMain
    {
        static void Main(string[] args)
        {
            try
            {
                ProximitySearch proximitySearch = new ProximitySearch(args);
                Console.WriteLine(proximitySearch.Search());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}