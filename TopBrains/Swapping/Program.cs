using System;

// Swapping: swap two values (or two variables)
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter first number:");
        int a = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Enter second number:");
        int b = int.Parse(Console.ReadLine() ?? "0");

        int temp = a;
        a = b;
        b = temp;

        Console.WriteLine($"After swap: {a} {b}");
    }
}
