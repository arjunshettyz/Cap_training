static class FinancialExtension
{
    public static double Brokerage(this double amount)       // Extension Method
    {
        return amount * 0.10;
    }
    public static double GST(this double amount)
    {
        return amount * 0.18;
    }
}