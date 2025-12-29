// See https://aka.ms/new-console-template for more information

class Program
{
    public static void ProcessTrade(Trade trade)
    {
        // Pattern Matching
        if(trade is EquityTrade eq)
        {
            Console.WriteLine("Equity Trade is Executing....");
            Console.WriteLine("Trade Value: "+ eq.CalculateValue());
        }
    } 
    public static void Main()
    {
        Console.WriteLine("----- Welcome to Smart Trading System! -----");

        PriceSnapshot ps1 = new PriceSnapshot
        {
            StockSymbol = "Apple",
            StockPrice = 250.45
        };

        PriceSnapshot ps2 = ps1;
        ps2.StockPrice = 130;

        PriceSnapshot ps3 = ps1;
        ps2.StockPrice = 180;

        Console.WriteLine("Original Stock Symbol: " + ps1.StockSymbol);
        Console.WriteLine("Original Stock Price: " + ps1.StockPrice);
        
        Console.WriteLine("Current Stock Symbol: " + ps2.StockSymbol);
        Console.WriteLine("Current Stock Price: " + ps2.StockPrice);
        
        Console.WriteLine("Current Stock Symbol: " + ps3.StockSymbol);
        Console.WriteLine("Current Stock Price: " + ps3.StockPrice);

        Console.WriteLine(ps1.ToString());

        TradeRepository<Trade> store = new TradeRepository<Trade>();
        Trade trade1 = new EquityTrade();
        Trade trade2 = new EquityTrade(102, "TCS", 5, 3050);
        Trade trade3 = new EquityTrade(103, "Apple", 10, 1289.78);

        store.AddTrade(trade1);
        store.AddTrade(trade2);
        store.AddTrade(trade3);

        store.PrintData();

        

        // Patttern Matching
        ProcessTrade(trade2);
        double amount = trade2.CalculateValue();
        double brokerage = amount.Brokerage();
        double gst = amount.GST();

        Console.WriteLine($"Brokerage amount: {brokerage}");
        Console.WriteLine($"GST amount: {gst}");
        TradeAnalytics.DisplayAnalytics();

        object boxing = TradeAnalytics.TotalTrade;      // Boxing
        Console.WriteLine("Boxing: " + boxing);

        int totalTrade = (int) boxing;   // unboxing
        Console.WriteLine("Unboxing: "+ totalTrade);

        Console.WriteLine(trade3.ToString());





    }
}
