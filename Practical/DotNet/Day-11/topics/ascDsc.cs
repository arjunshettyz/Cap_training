using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 5, 2, 8, 1, 3 };

        var ascending = numbers.OrderBy(n => n);
        var descending = numbers.OrderByDescending(n => n);

        Console.WriteLine("Ascending:");
        foreach (var n in ascending)
        {
            Console.WriteLine(n);
        }

        Console.WriteLine("Descending:");
        foreach (var n in descending)
        {
            Console.WriteLine(n);
        }
    }
}
