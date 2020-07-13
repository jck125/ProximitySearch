# ProximitySearch
### Jacob Kessler
### jacobkess@me.com

## Algorithm
Given valid arguments, the application will read the input file into an array of strings where each word in the input file occupies an element in the array and the words in the array are ordered as they were in the input file. The application loops through the array from the beginning until it finds one of the two keywords. When one of the keywords is found, we search through the next <range> strings and see if we encounter the other keyword. Each time we find the other keyword in this range, we increment the proximity counter. If both keywords are equal, we avoid double counting the first found keyword. After we have read to the end of the input file, we return the proximity counter.

## Complexity
In a worst case scenario, the input file would contain N words and the range would also be N. In this scenario, every word in the input file is either of the two keywords. The algorithm would stop at each word in the list and search through the end of the list, counting up each instance of the keywords. This means that when the algorithm encounters the first word in the input file, it would search the entire list of N words. For the next word, it would search the entire list of N-1 words. This would continue for the entire N list of words. 
To think of it in another way, for each element that we add to an already very large list of N words, we have to search through nearly the entire list an additional time. If we simply had to read through the list once, like we are when we are looking for the start of the keyword range, the complexity would be O(N). But, each time we find a keyword, we have to search through nearly the entire list again (assuming the range is N in this worst case senario), which would be an additional time complexity of O(N). Therefore, since we have to do O(N) worth of work O(N) times, the time complexity of this algorithm in the worst case senario is O(N^2).


## Built, Test, and Run Steps
Note that the following steps assume that the latest version of the .NET Core SDK is installed on this computer.

### Build Steps:
1. Navigate into the ProximitySearch directory that contains the solution (.sln) file
2. Type in the Terminal or Command Prompt: dotnet build

### Execute Tests Steps:
1. After completing the build steps, navigate into the ProximitySearchTests directory (cd ProximitySearchTests)
2. Type in the Terminal or Command Prompt: dotnet test

### Run Application Steps:
1. After completing the build steps, navigate into the ProximitySearch directory that contains the project (.csproj) file
2. Type in the Terminal or Command Prompt: dotnet run <keyword1> <keyword2> <range> <input_filename>
