var inputFilePath = "Input\\input.txt";

if (!File.Exists(inputFilePath))
{
    Console.WriteLine("File not found");
    return;
}

var lines = File.ReadAllLines(inputFilePath);
var rules = new List<(int left, int right)>();
int index = 0;

while (index < lines.Length && !string.IsNullOrWhiteSpace(lines[index]))
{
    var parts = lines[index].Split('|');
    int left = int.Parse(parts[0]);
    int right = int.Parse(parts[1]);
    rules.Add((left, right));
    index++;
}

index++; 
var comparer = new PageComparer(rules);

int total = 0;

for (; index < lines.Length; index++)
{
    var update = lines[index].Split(',').Select(int.Parse).ToArray();

    if (!IsUpdateValid(update, rules))
    {
        Array.Sort(update, comparer);
        int middle = update.Length / 2;
        total += update[middle];
    }
}

Console.WriteLine($"Total: {total}");

bool IsUpdateValid(int[] update, List<(int left, int right)> rules)
{
    for (int i = 0; i < update.Length; i++)
    {
        int current = update[i];

        foreach (var (left, right) in rules)
        {
            int leftIndex = Array.IndexOf(update, left);
            int rightIndex = Array.IndexOf(update, right);

            if (current == left && rightIndex != -1 && rightIndex < i)
                return false;

            if (current == right && leftIndex != -1 && leftIndex > i)
                return false;
        }
    }

    return true;
}

class PageComparer : IComparer<int>
{
    private readonly HashSet<(int left, int right)> ruleSet;

    public PageComparer(List<(int left, int right)> rules)
    {
        ruleSet = new HashSet<(int left, int right)>(rules);
    }

    public int Compare(int x, int y)
    {
        if (ruleSet.Contains((x, y)))
            return -1;

        if (ruleSet.Contains((y, x)))
            return 1;

        return 0;
    }
}