class SaleTransaction
{
    public string InvoiceNo {get; set;}
    public string CustomerName {get; set;}
    public string ItemName {get; set;}
    public int Quantity {get; set;}
    public decimal PurchaseAmount {get; set;}
    public decimal SellingAmount {get; set;}
    public string ProfitOrLossStatus;  // PROFIT / LOSS / BREAK-EVEN 
    public decimal ProfitOrLossAmount;
    public decimal ProfitMarginPercent;
    public static SaleTransaction LastTransaction;
    public static bool HasLastTransaction;


    public bool RegisterTransaction()
    {
        if(InvoiceNo == "" || InvoiceNo == null)
        {
            Console.WriteLine("Warning: Invoice No. Can't be empty!");
            return false;
        }
        if(Quantity <= 0)
        {
            Console.WriteLine("Warning: Quantity Must be in Positive!");
            return false;
        }
        if(PurchaseAmount <= 0)
        {
            Console.WriteLine("Warning: Purchase Amount Must Be in Positive!");
            return false;
        }
        if(SellingAmount < 0)
        {
            Console.WriteLine("Warning: Selling Amount Can't be in negative!");
            return false;
        }
        if(SellingAmount > PurchaseAmount)
        {
            ProfitOrLossStatus = "PROFIT";
            ProfitOrLossAmount = SellingAmount - PurchaseAmount;

        }else if(SellingAmount < PurchaseAmount)
        {
            ProfitOrLossStatus = "LOSS";
            ProfitOrLossAmount = PurchaseAmount - SellingAmount;
        }
        else
        {
            ProfitOrLossStatus = "BREAK-EVEN";
            ProfitOrLossAmount = 0.0m;
        }

        ProfitMarginPercent = ProfitOrLossAmount / PurchaseAmount * 100.0m;
        return true;

    }

    public static void DisplayLastTransaction()
    {
        Console.WriteLine("-------------- Last Transaction --------------");
        Console.WriteLine($"InvoiceNo: {LastTransaction.InvoiceNo}");
        Console.WriteLine($"Customer:  {LastTransaction.CustomerName}");
        Console.WriteLine($"Item: {LastTransaction.ItemName}");
        Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
        Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount:F2}");
        Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount:F2}");
        Console.WriteLine($"Status:  {LastTransaction.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent:F2}");
        Console.WriteLine("--------------------------------------------");
    }
    public static void RecomputeTransaction()
    {
        Console.WriteLine("-------------- Recomputed Last Transaction --------------");
        Console.WriteLine($"InvoiceNo: {LastTransaction.InvoiceNo}");
        Console.WriteLine($"Customer:  {LastTransaction.CustomerName}");
        Console.WriteLine($"Item: {LastTransaction.ItemName}");
        Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
        Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount:F2}");
        Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount:F2}");
        Console.WriteLine($"Status:  {LastTransaction.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent:F2}");
        Console.WriteLine("--------------------------------------------");
    }


}