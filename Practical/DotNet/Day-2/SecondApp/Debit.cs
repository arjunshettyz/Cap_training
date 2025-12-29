using System;

class Debit
{
    static int limit = 40000;
    public static int ATMWithdrawalLimitValidation(int balance, int amount)
    {
        
        if (amount <= limit)
        {
            balance -=  amount;
            limit -= amount;
            Console.WriteLine($"Transaction Successfully!, Your current balance: {balance}");
        }
        else
        {
            Console.WriteLine("Daily ATM withdrawal limit exceeded.");
        }

        return balance;
    }
    
    public static void EMIBurdenEvaluation(int monthlyIncome, int EMIAmount)
    {
        if(EMIAmount <= (monthlyIncome/100 * 40))
        {
            Console.WriteLine("EMI is financially manageable.");
        }
        else
        {
            Console.WriteLine("EMI exceeds safe income limit.");
        }
    }

    public static int transactionBasedDailySpendingCalculator(int balance)
    {
        Console.Write("Enter number of transactions: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int sum = 0;

        for(int i=1; i<=n; i++)
        {
            Console.Write($"Enter amount: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if(num <= balance)
            {
                sum += num;
                balance -= num;
                
            }
        }

        Console.WriteLine($"Total debit amount for the day: ₹{sum}");

        return balance;

    }

    public static void MinimumBalanceComplianceCheck()
    {
        int minimunBalance = 2000;
        Console.Write("Enter Current Balance: ");
        int currentBalance = Convert.ToInt32(Console.ReadLine());

        if(currentBalance < minimunBalance)
        {
            Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
        }
        else
        {
            Console.WriteLine("Minimum balance requirement satisfied.");
        }
    }
}