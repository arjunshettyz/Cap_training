class TradeRepository<T> where T : Trade
{
    private List<T> list = new List<T>();
    
    public void AddTrade(T Obj)
    {
        list.Add(Obj);
        Console.WriteLine("Trade Added Successfully!");
        TradeAnalytics.TotalTrade++;
    }

    public void PrintData()
    {
        Console.WriteLine("Trade Information: ");
        foreach(T trade in list)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"Trade Id: {trade.TradeId}");
            Console.WriteLine($"Trade Symbol: {trade.StockSymbol}");
            Console.WriteLine($"Trade Quantity: {trade.Quantity}");
            // Console.WriteLine($"Market Price: {trade.MarketPrice}");
            // Console.WriteLine($"Trade Value: {trade.CalculateValue()}");
            // Console.WriteLine($"Brokerage Amount: {Brokerage(trade.CalculateValue())}");
            // Console.WriteLine($"GST Amount: {GST(trade.CalculateValue())}");
            Console.WriteLine("---------------------");
        }
    }
}