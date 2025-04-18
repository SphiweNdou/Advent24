var inputFilePath = "Input\\input.txt";

if (!File.Exists(inputFilePath))
{
    Console.WriteLine("File not found");
    return;
}

var lines = File.ReadAllLines(inputFilePath);
var height = lines.Length;
var width = lines[0].Length;

var map = new char[width, height];

for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        map[x, y] = lines[y][x];
    }
}

var directions = new (int dx, int dy)[]
{
    (0, 1),   // Down
    (1, 0),   // Right
    (0, -1),  // Up
    (-1, 0),  // Left
    (1, 1),   // Down-right
    (-1, 1),  // Down-left
    (1, -1),  // Up-right
    (-1, -1)  // Up-left
};

int foundCount = 0;
string word = "XMAS";

bool SearchWord(int startX, int startY, int dx, int dy)
{
    for (int i = 0; i < word.Length; i++)
    {
        int x = startX + dx * i;
        int y = startY + dy * i;

        if (x < 0 || x >= width || y < 0 || y >= height)
            return false;

        if (map[x, y] != word[i])
            return false;
    }

    return true;
}

for (int x = 0; x < width; x++)
{
    for (int y = 0; y < height; y++)
    {
        foreach (var dir in directions)
        {
            if (SearchWord(x, y, dir.dx, dir.dy))
            {
                foundCount++;
            }
        }
    }
}

Console.WriteLine($"Found: {foundCount}");