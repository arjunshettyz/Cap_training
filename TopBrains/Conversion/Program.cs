using System;

class Program
{
    static void Main()
    {
        int feet = int.Parse(Console.ReadLine());
        double centimeters = ConvertFeetToCm(feet);
        Console.WriteLine(centimeters.ToString("F2"));
    }

    static double ConvertFeetToCm(int feet)
    {
        double cm = feet * 30.48;
        return Math.Round(cm, 2, MidpointRounding.AwayFromZero);
    }
}