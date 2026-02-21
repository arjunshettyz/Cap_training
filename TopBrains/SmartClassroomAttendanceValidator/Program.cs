using System;
using System.Collections.Generic;

// Validates classroom attendance: student ID, check-in time, and rules (e.g. late = absent)
class Program
{
    static void Main()
    {
        // Rule: valid if check-in time is before 9:00 AM (09:00)
        Console.WriteLine("Enter student ID:");
        string studentId = Console.ReadLine() ?? "";
        Console.WriteLine("Enter check-in time (HH:mm, 24-hour):");
        string timeInput = Console.ReadLine() ?? "00:00";

        if (string.IsNullOrWhiteSpace(studentId))
        {
            Console.WriteLine("Invalid - Missing student ID");
            return;
        }

        if (!TimeSpan.TryParse(timeInput, out TimeSpan checkIn))
        {
            Console.WriteLine("Invalid - Bad time format");
            return;
        }

        TimeSpan cutoff = new TimeSpan(9, 0, 0);
        if (checkIn <= cutoff)
            Console.WriteLine($"Valid - {studentId} attended on time");
        else
            Console.WriteLine($"Invalid - {studentId} late (after 09:00)");
    }
}
