using System;

class Program
{
    static void Main()
    {
        Predicate<int> isEligible = age => age >= 18;

        Console.WriteLine(isEligible(20));  
    }
}
