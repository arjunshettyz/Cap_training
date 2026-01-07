using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var evenNumbers = numbers.Where(n => n % 2 == 0);

        Console.WriteLine("Even numbers are:");

        foreach (var n in evenNumbers)
        {
            Console.WriteLine(n);
        }
    }
}
