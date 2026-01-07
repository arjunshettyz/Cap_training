using System;

delegate void PaymentHandler(decimal amount);

class PaymentService
{
    public event PaymentHandler PaymentSuccessful;

    public void MakePayment(decimal amount)
    {
        if (amount > 0 && amount <= 1_000_000)
        {
            PaymentSuccessful?.Invoke(amount);
        }
    }
}

class Program
{
    static void SendReceipt(decimal amount)
    {
        Console.WriteLine($"Receipt sent for ₹{amount}");
    }

    static void Main()
    {
        PaymentService service = new PaymentService();

        service.PaymentSuccessful += SendReceipt;

        service.MakePayment(25000);
    }
}
