using System;
using System.Collections.Generic;
using System.Linq;

// Search inside a collection: input list and key, output index or "Not found"
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter integers separated by spaces:");
        string[] parts = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var list = parts.Select(s => int.Parse(s)).ToList();

        Console.WriteLine("Enter value to search:");
        int key = int.Parse(Console.ReadLine() ?? "0");

        int index = list.IndexOf(key);
        if (index >= 0)
            Console.WriteLine($"Found at index {index}");
        else
            Console.WriteLine("Not found");
    }
}
