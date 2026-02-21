using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Sample Input
        List<string> input = new List<string>
        {
            "Ravi,87",
            "Kumar,98",
            "Arun,92"
        };

        // Convert to objects, sort by score descending, select names
        List<string> result = input
            .Select(x => new
            {
                Name = x.Split(',')[0],
                Score = int.Parse(x.Split(',')[1])
            })
            .OrderByDescending(x => x.Score)
            .Select(x => x.Name)
            .ToList();

        // Output
        foreach (var name in result)
        {
            Console.WriteLine(name);
        }
    }
}