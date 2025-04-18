var inputFilePath = "Input\\input.txt";

if (!File.Exists(inputFilePath))
{
    Console.WriteLine("File not found");
    return;
}

ulong total = 0;
var lines = File.ReadAllLines(inputFilePath);

foreach (var line in lines)
{
    var parts = line.Split(":");
    ulong expected = ulong.Parse(parts[0].Trim());
    var equation = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var numbers = equation.Select(ulong.Parse).ToArray();

    if (CanSolve(expected, numbers))
    {
        total += expected;
    }
}

Console.WriteLine(total);

// --------------------- Recursive Solver ---------------------

bool CanSolve(ulong expected, ulong[] numbers)
{
    return Solve(numbers[0], 0, expected, numbers);
}

bool Solve(ulong current, int index, ulong expected, ulong[] numbers)
{
    if (current > expected)
        return false;

    if (index == numbers.Length - 1)
        return current == expected;

    ulong next = numbers[index + 1];

    if (Solve(current + next, index + 1, expected, numbers))
        return true;

    if (Solve(current * next, index + 1, expected, numbers))
        return true;

    return false;
}
