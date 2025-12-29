using System;
abstract class Trade
{
    public int TradeId {get; set;}
    public string StockSymbol {get; set;}
    public int Quantity {get; set;}

    public Trade(int tradeId, string symbol, int quantity)
    {
        TradeId = tradeId;
        StockSymbol = symbol;
        Quantity = quantity;
    }

    public Trade(){}

    public abstract double CalculateValue();

    public override string ToString()
    {
        return $"Information: \n Trade ID: {TradeId}\n Stock Symbol: {StockSymbol}\n Stock Quantity: {Quantity}";
    }
}