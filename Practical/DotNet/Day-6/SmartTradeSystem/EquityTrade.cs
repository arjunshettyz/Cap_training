class EquityTrade: Trade
{

    public double? MarketPrice {get; set;}

    public EquityTrade(int tradeId, string symbol, int quantity, double price):base(tradeId, symbol, quantity)
    {
        MarketPrice = price;
    }

    public EquityTrade(){}


    public override double CalculateValue()
    {
        double price = MarketPrice ?? 0;
        return price * Quantity;
    }

    public override string ToString()
    {
        // base.ToString();
        // Console.WriteLine("Market Price: " + MarketPrice);
        return base.ToString() + "\n Market Price: " + MarketPrice;
    }
}