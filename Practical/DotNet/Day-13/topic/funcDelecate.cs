using System;
class Program
{
    static void Main()
    {
        Func<decimal, decimal, decimal> calculateDiscount =
            (price, discount) => price - (price * discount / 100);

        Console.WriteLine(calculateDiscount(1000, 10));
    }
}