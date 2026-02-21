using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Input
        List<string> products = new List<string>
        {
            "Pen", "Book", "Pen", "Pencil", "Book"
        };

        // Find duplicates
        List<string> duplicates = products
            .GroupBy(p => p)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        // Output
        Console.WriteLine("[" + string.Join(", ", duplicates.Select(d => $"\"{d}\"")) + "]");
    }
}