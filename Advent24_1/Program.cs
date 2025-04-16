using System.Collections;
using System.Runtime.CompilerServices;

string inputFilePath = "Input\\input.txt";

if (!File.Exists(inputFilePath))
{
    Console.WriteLine("File not found");
    return;
}

try
{
    List<int> locationGroupA = new List<int>();
    List<int> locationGroupB = new List<int>();
    int count = 0;

    foreach (var line in File.ReadAllLines(inputFilePath))
    {
        var locationInputs = line.Split("  ");

        if ((locationInputs.Length > 0))
        {
            locationGroupA.Add(int.Parse(locationInputs[0]));
            locationGroupB.Add(int.Parse(locationInputs[1]));
        }

        count++;
    }

    locationGroupA.Sort();
    locationGroupB.Sort();
    int totalDistance = TotalDistanceBetweenLocations(locationGroupA, locationGroupB);
    int similarityScore = SimilarityScoreBetweenLocations(locationGroupA, locationGroupB);

    Console.WriteLine($"The toatal Distance is: {totalDistance}");
    Console.WriteLine($"The similarity score is: {similarityScore}");

}
catch ( Exception e)
{
    Console.WriteLine("Error:" + e.ToString());
    Console.ReadLine();
}

static int TotalDistanceBetweenLocations(List<int> locationGroupA, List<int> locationGroupB)
{
    int totalDistance = 0;

    for (int i = 0; i < locationGroupA.Count; i++)
    {
        totalDistance += Math.Abs(locationGroupA[i] - locationGroupB[i]);
    }

    return totalDistance;
}

static int SimilarityScoreBetweenLocations(List<int> locationGroupA, List<int> locationGroupB)
{
    int totalScore = 0;
    List<int> uniqueLocation = new List<int>();

    for (int i = 0; i < locationGroupA.Count; i++)
    {
        if (!uniqueLocation.Contains(locationGroupA[i]))
        {
            uniqueLocation.Add(locationGroupA[i]);
            int matchesInGroupB = locationGroupB.Where(location => location == locationGroupA[i]).Count();
            totalScore += matchesInGroupB * locationGroupA[i];
        }
    }

    return totalScore;
}