using System;

class Program
{
    static void Main()
    {
        // Read initial balance
        int initialBalance = int.Parse(Console.ReadLine());

        // Read number of transactions
        int n = int.Parse(Console.ReadLine());

        // Read transactions
        int[] transactions = new int[n];
        for (int i = 0; i < n; i++)
        {
            transactions[i] = int.Parse(Console.ReadLine());
        }

        int finalBalance = GetFinalBalance(initialBalance, transactions);

        Console.WriteLine(finalBalance);
    }

    static int GetFinalBalance(int balance, int[] transactions)
    {
        foreach (int t in transactions)
        {
            if (t >= 0)
            {
                // Deposit
                balance += t;
            }
            else
            {
                // Withdraw only if enough balance
                if (balance + t >= 0)
                {
                    balance += t;
                }
            }
        }
        return balance;
    }
}