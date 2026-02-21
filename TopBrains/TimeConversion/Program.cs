using System;

// Time conversion: 12-hour AM/PM to 24-hour (e.g. 02:30 PM -> 14:30)
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter time in 12-hour format (e.g. 02:30 PM or 11:45 AM):");
        string input = (Console.ReadLine() ?? "").Trim();
        string[] parts = input.Split(' ');
        if (parts.Length < 2)
        {
            Console.WriteLine("Invalid format. Use e.g. 02:30 PM");
            return;
        }
        string timePart = parts[0];
        string ampm = parts[1].ToUpper();

        string[] hm = timePart.Split(':');
        if (hm.Length != 2 || !int.TryParse(hm[0], out int h) || !int.TryParse(hm[1], out int m))
        {
            Console.WriteLine("Invalid time");
            return;
        }

        if (ampm == "PM" && h != 12) h += 12;
        if (ampm == "AM" && h == 12) h = 0;

        Console.WriteLine($"{h:D2}:{m:D2}");
    }
}
