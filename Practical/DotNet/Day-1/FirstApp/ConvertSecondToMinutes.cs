using System;

class ConvertSecondToMinutes
{
    public static void SecondToMinutes()
    {
        Console.Write("Enter Secound: ");
        double sec = Convert.ToInt32(Console.ReadLine());
        double Minutes = (sec / 60);

        Console.WriteLine($"{sec} in Minutes is: {Minutes}");
    }
}