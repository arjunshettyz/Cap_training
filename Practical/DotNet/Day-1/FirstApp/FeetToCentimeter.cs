using System;

class Feet
{
    public static void FeetToCentimeter()
    {
        Console.Write("Enter Feet: ");
        double feet = Convert.ToDouble(Console.ReadLine());
        double foot = 30.48;
        double res = feet * foot;

        Console.WriteLine($"{feet} in Centimeter is: {res}");


    }
}