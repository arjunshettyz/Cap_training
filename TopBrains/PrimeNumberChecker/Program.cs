using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int n = int.Parse(Console.ReadLine() ?? "0");

        if (IsPrime(n))
            Console.WriteLine("Prime");
        else
            Console.WriteLine("Not Prime");
    }

    static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
        for (int i = 3; i * i <= n; i += 2)
            if (n % i == 0) return false;
        return true;
    }
}
