using System;

class Program
{
    static void Main()
    {
        double radius = double.Parse(Console.ReadLine());
        double area = GetCircleArea(radius);
        Console.WriteLine(area.ToString("F2"));
    }

    static double GetCircleArea(double radius)
    {
        double area = Math.PI * radius * radius;
        return Math.Round(area, 2, MidpointRounding.AwayFromZero);
    }
}