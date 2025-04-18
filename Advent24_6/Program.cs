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

// Load map and find starting point
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

bool IsOutOfBounds(int x, int y)
{
    return x < 0 || y < 0 || x >= width || y >= height;
}

HashSet<(int x, int y)> GetPotentialObstructionPositions(int sx, int sy)
{
    var visited = new HashSet<(int x, int y)>();
    int dx = 0;
    int dy = -1;

    int x = sx;
    int y = sy;

    while (true)
    {
        visited.Add((x, y));
        int nx = x + dx;
        int ny = y + dy;

        if (IsOutOfBounds(nx, ny))
            break;

        if (map[nx, ny] == '#')
        {
            // turn right: (dx, dy) => (-dy, dx)
            int temp = dx;
            dx = -dy;
            dy = temp;
            nx = x;
            ny = y;
        }

        if (IsOutOfBounds(nx, ny))
            break;

        x = nx;
        y = ny;
    }

    return visited;
}

bool DoesGuardLoop(int sx, int sy, int obsX, int obsY)
{
    var visited = new HashSet<((int x, int y) pos, (int dx, int dy) dir)>();
    int dx = 0;
    int dy = -1;

    int x = sx;
    int y = sy;

    while (true)
    {
        if (visited.Contains(((x, y), (dx, dy))))
            return true;

        visited.Add(((x, y), (dx, dy)));

        int nx = x + dx;
        int ny = y + dy;

        if (IsOutOfBounds(nx, ny))
            break;

        bool isBlocked = map[nx, ny] == '#' || (nx == obsX && ny == obsY);

        if (isBlocked)
        {
            int temp = dx;
            dx = -dy;
            dy = temp;
            nx = x;
            ny = y;
        }

        if (IsOutOfBounds(nx, ny))
            break;

        x = nx;
        y = ny;
    }

    return false;
}

// Run loop logic
var potentialObstructions = GetPotentialObstructionPositions(startX, startY);
int obstructionCount = 0;

foreach (var (x, y) in potentialObstructions)
{
    if (x == startX && y == startY)
        continue;

    if (DoesGuardLoop(startX, startY, x, y))
    {
        obstructionCount++;
    }
}

Console.WriteLine($"Obstruction count: {obstructionCount}");
