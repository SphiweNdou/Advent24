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

    int totalDistance = 0;

    for (int i = 0; i < locationGroupA.Count; i++)
    {
        totalDistance += Math.Abs(locationGroupA[i] - locationGroupB[i]);
    }
    Console.WriteLine($"The toatal Distance is: {totalDistance}");

} catch ( Exception e)
{
    Console.WriteLine("Error:" + e.ToString());
    Console.ReadLine();
}
