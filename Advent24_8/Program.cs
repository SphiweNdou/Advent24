var inputFilePath = "Input\\input.txt";

if (!File.Exists(inputFilePath))
{
    Console.WriteLine("File not found");
    return;
}

var lines = File.ReadAllLines(inputFilePath);
int width = lines[0].Length;
int height = lines.Length;

var grid = new char[width, height];
var antennas = new Dictionary<char, List<(int x, int y)>>();

for (int y = 0; y < height; y++)
{
    var line = lines[y];
    for (int x = 0; x < width; x++)
    {
        var character = line[x];
        grid[x, y] = character;

        if (character != '.')
        {
            if (!antennas.ContainsKey(character))
            {
                antennas[character] = new List<(int x, int y)>();
            }

            antennas[character].Add((x, y));
        }
    }
}

var antinodes = new HashSet<(int x, int y)>();

foreach (var kvp in antennas)
{
    var points = kvp.Value;

    for (int i = 0; i < points.Count; i++)
    {
        for (int j = i + 1; j < points.Count; j++)
        {
            var (x1, y1) = points[i];
            var (x2, y2) = points[j];

            int dx = x2 - x1;
            int dy = y2 - y1;

            antinodes.Add((x1 - dx, y1 - dy));
            antinodes.Add((x2 + dx, y2 + dy));
        }
    }
}

bool IsInBounds(int x, int y)
{
    return x >= 0 && x < width && y >= 0 && y < height;
}

int result = antinodes.Count(pos => IsInBounds(pos.x, pos.y));
Console.WriteLine(result);
