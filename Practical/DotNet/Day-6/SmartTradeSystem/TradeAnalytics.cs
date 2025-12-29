static class TradeAnalytics
{
    public static int TotalTrade {get; set;}
    public static void DisplayAnalytics()
    {
        Console.WriteLine("-----Trade Analytics------");
        Console.WriteLine("Total Trade Executed: " + TotalTrade);
    }
}