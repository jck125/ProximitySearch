# ProximitySearch
### Jacob Kessler
### jacobkess@me.com

## Algorithm
Given valid arguments, the application will read the input file into an array of strings where each word in the input file occupies an element in the array and the words in the array are ordered as they were in the input file. The application loops through the array from the beginning until it finds one of the two keywords. When one of the keywords is found, we search through the next <range> strings and see if we encounter the other keyword. Each time we find the other keyword in this range, we increment the proximity counter. If both keywords are equal, we avoid double counting the first found keyword. After we have read to the end of the input file, we return the proximity counter.


## Built, Test, and Run Steps
Note that the following steps assume that the latest version of the .NET Core SDK is installed on this computer.

### Build Steps:
1. Navigate into the ProximitySearch solution directory (cd ProximitySearch)
2. Type in the Terminal or Command Prompt: dotnet build

### Execute Tests Steps:
1. After completing the build steps, navigate into the ProximitySearchTests directory (cd ProximitySearchTests)
2. Type in the Terminal or Command Prompt: dotnet test

### Run Application Steps:
1. After completing the build steps, navigate into the ProximitySearch project directory (cd ProximitySearch)
2. Type in the Terminal or Command Prompt: dotnet run <keyword1> <keyword2> <range> <input_filename>
