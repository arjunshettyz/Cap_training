using System;

class Program
{
    static void Main()
    {
        Comparison<int> sortDescending = (a, b) => b.CompareTo(a);

        Console.WriteLine(sortDescending(5, 10));
        Console.WriteLine(sortDescending(10, 5));
        Console.WriteLine(sortDescending(5, 5));
    }
}
