using System.Text.RegularExpressions;

string inputFilePath = "Input\\input.txt";

if (!File.Exists(inputFilePath))
{
    Console.WriteLine("File not found");
    return;
}
try
{
    var input = File.ReadAllText(inputFilePath);

    var mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
    var doPattern = @"do\(\)";
    var dontPattern = @"don't\(\)";

    var mulMatches = Regex.Matches(input, mulPattern);
    var doMatches = Regex.Matches(input, doPattern);
    var dontMatches = Regex.Matches(input, dontPattern);

    var doIndexes = new List<int>();
    foreach (Match match in doMatches)
    {
        doIndexes.Add(match.Index);
    }

    var dontIndexes = new List<int>();
    foreach (Match match in dontMatches)
    {
        dontIndexes.Add(match.Index);
    }

    var togglePoints = doIndexes.Concat(dontIndexes).OrderBy(i => i).ToArray();
    var currentToggleIndex = 0;
    var isEnabled = true;

    int total = 0;

    foreach (Match match in mulMatches)
    {
        int matchIndex = match.Index;

        if (currentToggleIndex < togglePoints.Length && matchIndex > togglePoints[currentToggleIndex])
        {
            bool isDoCommand = doIndexes.Contains(togglePoints[currentToggleIndex]);
            isEnabled = isDoCommand;

            currentToggleIndex++;
        }

        if (isEnabled)
        {
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);

            total += x * y;
        }
    }

    Console.WriteLine($"The toatal is: {total}");
}
catch (Exception e)
{
    Console.WriteLine("Error:" + e.ToString());
    Console.ReadLine();
}