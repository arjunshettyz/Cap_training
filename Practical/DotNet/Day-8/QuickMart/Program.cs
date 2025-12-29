// See https://aka.ms/new-console-template for more information

class Program
{
    public static void Main()
    {
        // Console.WriteLine("Welcome TO Day 8!");
        Console.WriteLine("Welcome TO Quick Mart Traders Application!");
        int choice = 0;

        while (choice != 4)
        {
            Console.WriteLine("================== QuickMart Traders ==================");
            Console.WriteLine(" 1. Create New Transaction (Enter Purchase & Selling Details). \n 2.View Last Transaction. \n 3.Calculate Profit / Loss(Recompute & Print). \n 4.Exit");
            Console.Write("Enter your option: ");

            while (!int.TryParse(Console.ReadLine(), out choice) || choice <= 0)
            {
                Console.WriteLine("Error: Invalid Input!");
            }

            switch (choice)
            {
                case 1:
                    {
                        Console.Write("Enter Invoice No: ");
                        string invoiceNo = Console.ReadLine();

                        Console.Write("Enter Customer Name: ");
                        string customerName = Console.ReadLine();

                        Console.Write("Enter Item Name: : ");
                        string itemName = Console.ReadLine();

                        Console.Write("Enter Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        Console.Write("Enter Purchase Amount (total): ");
                        decimal purchaseAmount = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter Selling Amount (total): ");
                        decimal sellingAmount = decimal.Parse(Console.ReadLine());

                        SaleTransaction transaction = new SaleTransaction
                        {
                            InvoiceNo = invoiceNo,
                            CustomerName = customerName,
                            ItemName = itemName,
                            Quantity = quantity,
                            PurchaseAmount = purchaseAmount,
                            SellingAmount = sellingAmount
                        };
                        bool isCreated = transaction.RegisterTransaction();

                        if (isCreated)
                        {
                            SaleTransaction.LastTransaction = transaction;
                            SaleTransaction.HasLastTransaction = true;
                            Console.WriteLine("Transaction saved successfully.");
                            Console.WriteLine($"Status: {transaction.ProfitOrLossStatus}");
                            Console.WriteLine($"Profit/Loss Amount: {transaction.ProfitOrLossAmount:F2}");
                            Console.WriteLine($"Profit Margin (%): {transaction.ProfitMarginPercent:F2}");
                            Console.WriteLine($"-----------------------------------------------------");
                        }

                        break;
                    }
                case 2:
                    {
                        if (SaleTransaction.HasLastTransaction)
                        {
                            SaleTransaction.DisplayLastTransaction();
                        }
                        else
                        {
                            Console.WriteLine("No transaction available. Please create a new transaction first.");
                        }
                        break;
                    }
                case 3:
                    {
                        if (SaleTransaction.HasLastTransaction)
                        {
                            SaleTransaction.RecomputeTransaction();
                        }
                        else
                        {
                            Console.WriteLine("No transaction available. Please create a new transaction first.");
                        }
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Thank you. Application closed normally.");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Warning: Please Choose From Menu Only!");
                        break;
                    }
            }
        }
        Console.WriteLine("-------- Thanks For Using QuickMart Application. ---------");


    }
}