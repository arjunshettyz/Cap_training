// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to Day 6!");

        // StockPrice originalPrice = new StockPrice
        // {
        //     StockSymbol = "TCS",
        //     price = 3000

        // };
        // StockPrice copiedPrice = originalPrice;
        // copiedPrice.price = 2000;

        // Console.WriteLine("Original: " + originalPrice.price);
        // Console.WriteLine("Copied: " + copiedPrice.price);

        // Trade originalTrade = new Trade
        // {
        //     TradeId = 101,
        //     StockSymbol = "APPLE",
        //     Quantity = 5

        // };

        // Trade copiedTrade = originalTrade;
        // copiedTrade.Quantity = 10;

        // Console.WriteLine("Original Trade: " + originalTrade.Quantity);
        // Console.WriteLine("Copied Trade: " + copiedTrade.Quantity);



        // Portfolio p1 = new Portfolio{Name="Growth"};
        // Portfolio p2 = new Portfolio{Name="Growth"};

        // Console.WriteLine(p1.Equals(p2));
        // Console.WriteLine(p1 == p2);
        // Console.WriteLine(p1.GetHashCode() == p2.GetHashCode());


        // Console.WriteLine("Get Hash Code: " + p1.GetHashCode());
        // Console.WriteLine("Get Hash Code: " + p2.GetHashCode());

        // GetType()
        // Trade t = new EquityTrade();
        // Console.WriteLine(t.GetType());

        // Repository<String> repo = new Repository<String>();
        // repo.Data = "Aryan";

        // Console.WriteLine(repo.Data);

        // Gemeric method
        Calculator cs1 = new Calculator();
        int res = cs1.Calculate(1,2);
        Console.WriteLine("Result: " + res);

        double res2 = cs1.Calculate(12.23, 12);
        Console.WriteLine("Result: " + res2);

        string res3 = cs1.Calculate("Aryan", "Mohit");
        Console.WriteLine("Result: " + res3);

        Console.WriteLine("Result: " + cs1.Calculate(5, 7.4));



        // List<Trade> list = new List<Trade>();







    }
}
