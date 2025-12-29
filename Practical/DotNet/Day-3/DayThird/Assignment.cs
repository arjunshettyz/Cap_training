class BankAccount
{
    private int AccountNumber;
    private double Balance;
    static string BankName = "SBI Bank";

    public BankAccount(int AccountNumber, double Balance)
    {
        this.AccountNumber = AccountNumber;
        this.Balance = Balance;
    }

    public void Deposit(double amount)
    {
        if(amount < 0)
        {
            Console.WriteLine($"Invalid!, Amount Should be in Positive");
            
        }
        else
        {
            Balance += amount;
            Console.WriteLine($"Deposited Successfully!, Updated Balance: {Balance}");
        }

    }

    public void Deposit(ref double amount)
    {
        if(amount < 0)
        {
            Console.WriteLine($"Invalid!, Amount Should be in Positive");
        }
        else
        {
            Balance += amount;
            Console.WriteLine($"Deposited Successfully!, Updated Balance: {Balance}");
        }
    }

    public void Withdraw(double amount)
    {
        Balance -= amount;
        Console.WriteLine($"Withdraw Successfully!, Current Balance: {Balance}");
    }

    public bool Withdraw(double amount, out string message)
    {
        if(amount < 0)
        {
            message = "Invalid!, Amount Should be in Positive";
            return false;
        }else if (amount > Balance)
        {
            message = "Insufficient balance";
            return false;
        }
        Balance -= amount;
        message = "Withdraw Successfully!";
        return true;
    }

    public void Display()
    {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Bank Name: {BankName}");
        Console.WriteLine($"You Current Balance is: ₹{Balance}");
    }
}

