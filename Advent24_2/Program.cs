string inputFilePath = "Input\\input.txt";

if (!File.Exists(inputFilePath))
{
    Console.WriteLine("File not found");
    return;
}

try
{
    List<List<int>> reports = new List<List<int>>();

    foreach (var report in File.ReadAllLines(inputFilePath))
    {
        var levels = report.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select( level => int.Parse(level)).ToList();
        if (report != null) reports.Add(levels);
    }

    int safeRpeortCount = NumberOfSafeReports(reports);

    Console.WriteLine($"The toatal safe reports: {safeRpeortCount}");

}
catch (Exception e)
{
    Console.WriteLine("Error:" + e.ToString());
    Console.ReadLine();
}

int NumberOfSafeReports (List<List<int>> reports)
{
    int numberOfSafeReports = 0;

    foreach (var report in reports)
    {
        if(LevelsIncreasing(report) ^ LevelsDecreasing(report)) numberOfSafeReports++;
    }

    return numberOfSafeReports;
}

bool LevelsIncreasing (List<int> levels)
{
    int lastLevel = levels[0];

    for ( int i = 1;  i < levels.Count; i++)
    {
        int currentLevel = levels[i];

        if ((currentLevel <= lastLevel) || (Math.Abs(currentLevel - lastLevel) > 3)) 
            return false;

        lastLevel = currentLevel;
    }

    return true;
}

bool LevelsDecreasing (List<int> levels)
{
    int lastLevel = levels[0];

    for (int i = 1; i < levels.Count; i++)
    {
        int currentLevel = levels[i];

        if ( (currentLevel >= lastLevel) || ( Math.Abs(lastLevel - currentLevel) > 3) )
            return false;

        lastLevel = currentLevel;
    }

    return true;
}
