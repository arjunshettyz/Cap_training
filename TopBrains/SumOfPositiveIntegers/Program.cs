using System;
using System.Linq;

// Sum of positive integers: from a list, sum only the positive numbers
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter integers separated by spaces:");
        string[] parts = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = parts.Select(s => int.Parse(s)).ToArray();

        int sum = numbers.Where(n => n > 0).Sum();
        Console.WriteLine($"Sum of positive integers: {sum}");
    }
}
