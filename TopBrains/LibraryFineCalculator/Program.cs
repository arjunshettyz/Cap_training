using System;

// Library fine: typically per day overdue (e.g. 0.50 per day, max cap)
class Program
{
    static void Main()
    {
        const decimal finePerDay = 0.50m;
        const decimal maxFine = 25.00m;

        Console.WriteLine("Enter days overdue:");
        int daysOverdue = int.Parse(Console.ReadLine() ?? "0");

        if (daysOverdue <= 0)
        {
            Console.WriteLine("No fine.");
            return;
        }

        decimal fine = Math.Min((decimal)daysOverdue * finePerDay, maxFine);
        Console.WriteLine($"Fine: ${fine:F2}");
    }
}
