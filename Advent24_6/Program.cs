var inputFilePath = "Input\\input.txt";

if (!File.Exists(inputFilePath))
{
    Console.WriteLine("File not found");
    return;
}

var lines = File.ReadAllLines(inputFilePath);
int height = lines.Length;
int width = lines[0].Length;

var map = new char[width, height];
int startX = 0;
int startY = 0;

// Load map and find starting position
for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        map[x, y] = lines[y][x];
        if (map[x, y] == '^')
        {
            startX = x;
            startY = y;
        }
    }
}

int CountSteps(int sx, int sy)
{
    var visited = new HashSet<(int x, int y)>();
    int dx = 0;
    int dy = -1; // initial direction: up
    int x = sx;
    int y = sy;

    while (true)
    {
        visited.Add((x, y));
        int nextX = x + dx;
        int nextY = y + dy;

        if (IsOutOfBounds(nextX, nextY)) break;

        if (map[nextX, nextY] == '#')
        {
            // turn right: (dx, dy) => (-dy, dx)
            int temp = dx;
            dx = -dy;
            dy = temp;

            nextX = x + dx;
            nextY = y + dy;
        }

        if (IsOutOfBounds(nextX, nextY)) break;

        x = nextX;
        y = nextY;
    }

    return visited.Count;
}

bool IsOutOfBounds(int x, int y)
{
    return x < 0 || y < 0 || x >= width || y >= height;
}

Console.WriteLine(CountSteps(startX, startY));
