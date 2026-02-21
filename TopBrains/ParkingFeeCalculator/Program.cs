using System;

// Parking fee: first hour fixed, then hourly rate (e.g. first 2 hours = 10, then 5 per hour)
class Program
{
    static void Main()
    {
        const decimal firstTwoHours = 10.00m;
        const decimal perHourAfter = 5.00m;

        Console.WriteLine("Enter hours parked (decimal allowed, e.g. 2.5):");
        double hours = double.Parse(Console.ReadLine() ?? "0");

        if (hours <= 0)
        {
            Console.WriteLine("Fee: $0.00");
            return;
        }

        decimal fee;
        if (hours <= 2)
            fee = firstTwoHours;
        else
            fee = firstTwoHours + (decimal)(Math.Ceiling(hours - 2) * (double)perHourAfter);

        Console.WriteLine($"Parking Fee: ${fee:F2}");
    }
}
