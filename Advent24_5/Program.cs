using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

var inputFilePath = "Input\\input.txt";

if (!File.Exists(inputFilePath))
{
    Console.WriteLine("File not found");
    return;
}

var lines = File.ReadAllLines(inputFilePath);
var rules = new List<(int left, int right)>();

int index = 0;

// Read rules (until first empty line)
while (index < lines.Length && !string.IsNullOrWhiteSpace(lines[index]))
{
    var parts = lines[index].Split('|');
    int left = int.Parse(parts[0]);
    int right = int.Parse(parts[1]);
    rules.Add((left, right));
    index++;
}

index++; // Skip empty line

int total = 0;

// Read updates
for (; index < lines.Length; index++)
{
    var update = lines[index].Split(',').Select(int.Parse).ToArray();

    bool isValid = true;

    for (int i = 0; i < update.Length; i++)
    {
        int current = update[i];

        foreach (var rule in rules)
        {
            int left = rule.left;
            int right = rule.right;

            int leftIndex = Array.IndexOf(update, left);
            int rightIndex = Array.IndexOf(update, right);

            if (current == left && rightIndex != -1 && rightIndex < i)
            {
                isValid = false;
                break;
            }

            if (current == right && leftIndex != -1 && leftIndex > i)
            {
                isValid = false;
                break;
            }
        }

        if (!isValid)
            break;
    }

    if (isValid)
    {
        int middleIndex = update.Length / 2;
        total += update[middleIndex];
    }
}

Console.WriteLine($"Total: {total}");
