using System;

class Program
{
    static void Main()
    {
        int year = int.Parse(Console.ReadLine());

        if (IsLeapYear(year))
            Console.WriteLine("Leap Year");
        else
            Console.WriteLine("Not Leap Year");
    }

    static bool IsLeapYear(int year)
    {
        if (year % 400 == 0)
            return true;
        if (year % 100 == 0)
            return false;
        if (year % 4 == 0)
            return true;
        return false;
    }
}