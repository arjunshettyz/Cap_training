using System;

// E-commerce discount: e.g. 10% above 100, 20% above 500
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter order amount:");
        decimal amount = decimal.Parse(Console.ReadLine() ?? "0");

        decimal discountPercent = 0;
        if (amount >= 500) discountPercent = 20;
        else if (amount >= 100) discountPercent = 10;

        decimal discount = amount * (discountPercent / 100m);
        decimal final = amount - discount;

        Console.WriteLine($"Discount: {discountPercent}%");
        Console.WriteLine($"Amount after discount: ${final:F2}");
    }
}
