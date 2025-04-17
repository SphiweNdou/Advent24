using System.Text.RegularExpressions;

string inputFilePath = "Input\\input.txt";

if (!File.Exists(inputFilePath))
{
    Console.WriteLine("File not found");
    return;
}

try
{
    int totalValue = 0;

    foreach (var line in File.ReadAllLines(inputFilePath))
    {
        var multiples = Regex.Matches(line, @"mul\(\d{1,3},\d{1,3}\)").ToList();
        foreach (var mul in multiples)
        {
            int comaIndex = mul.Value.IndexOf(',');
            int closingIndex = mul.Value.IndexOf(')'); 
            int a = int.Parse(mul.Value.Substring(4,comaIndex - 4));
            int b = int.Parse(mul.Value.Substring(comaIndex + 1, (closingIndex - comaIndex)-1));
            totalValue += a * b;
        }
    }

    Console.WriteLine($"The toatal is: {totalValue}");

}
catch (Exception e)
{
    Console.WriteLine("Error:" + e.ToString());
    Console.ReadLine();
}