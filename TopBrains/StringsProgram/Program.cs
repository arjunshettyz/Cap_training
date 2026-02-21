using System;

// Strings program: common operations - length, reverse, uppercase, concatenation
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a string:");
        string s = Console.ReadLine() ?? "";

        Console.WriteLine($"Length: {s.Length}");
        Console.WriteLine($"Uppercase: {s.ToUpper()}");
        Console.WriteLine($"Reverse: {Reverse(s)}");

        Console.WriteLine("Enter another string to concatenate:");
        string t = Console.ReadLine() ?? "";
        Console.WriteLine($"Concatenated: {s + t}");
    }

    static string Reverse(string s)
    {
        char[] a = s.ToCharArray();
        Array.Reverse(a);
        return new string(a);
    }
}
