struct PriceSnapshot
{
    public string StockSymbol {get; set;}
    public double StockPrice {get; set;}

    public override string ToString()
    {
        return "-----------Coming from Overrided ToString Method-------------";
    }

}