using System;

// Ropeway: assign people to cabins (capacity per cabin), output number of cabins needed
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter total number of people:");
        int people = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Enter cabin capacity:");
        int capacity = int.Parse(Console.ReadLine() ?? "1");

        if (capacity <= 0)
        {
            Console.WriteLine("Invalid capacity");
            return;
        }

        int cabinsNeeded = (people + capacity - 1) / capacity;
        Console.WriteLine($"Cabins needed: {cabinsNeeded}");
    }
}
