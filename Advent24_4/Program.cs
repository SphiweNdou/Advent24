var inputFilePath = "Input\\input.txt";

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

var diagonalDirections = new (int dx, int dy)[]
{
    (1, 1),    // down-right
    (-1, 1),   // down-left
    (1, -1),   // up-right
    (-1, -1)   // up-left
};

string word = "MAS";
int foundCount = 0;

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
        int diagonalCount = 0;

        foreach (var direction in diagonalDirections)
        {
            int dx = direction.dx;
            int dy = direction.dy;

            int startX = x - dx;
            int startY = y - dy;

            if (SearchWord(startX, startY, dx, dy))
            {
                diagonalCount++;
            }
        }

        if (diagonalCount == 2)
        {
            foundCount++;
        }
    }
}

Console.WriteLine($"Found: {foundCount}");