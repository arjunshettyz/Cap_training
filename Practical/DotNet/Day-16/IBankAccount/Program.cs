using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public interface IBankAccountOperation
{
    void Deposit(decimal d);
    void Withdraw(decimal d);
    decimal ProcessOperation(string message);
}

class BankOperations : IBankAccountOperation
{
    private decimal balance = 0;

    public void Deposit(decimal d)
    {
        if (d <= 0) return;
        balance += d;
    }

    public void Withdraw(decimal d){
        if( d<= 0) return;

        if(d <= 0){
            balance -= d;
        }else{
            throw new InvalidOperationException("Insufficient funds");
        }
    }


    public decimal ProcessOperation(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            return balance;

        message = message.ToLower();

        Match match = Regex.Match(message, @"\d+");
        decimal amount = match.Success ? decimal.Parse(match.Value) : 0;

        if (message.Contains("balance") || message.Contains("money"))
        {
            return balance;
        }

        if (message.Contains("deposit") ||
            message.Contains("invest") ||
            message.Contains("transfer"))
        {
            Deposit(amount);
            return balance;
        }

        if (message.Contains("withdraw") ||
            message.Contains("pull"))
        {
            Withdraw(amount);
            return balance;
        }

        return balance;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter;

        string outputPath = Environment.GetEnvironmentVariable("OUTPUT_PATH");
        if (!string.IsNullOrEmpty(outputPath))
            textWriter = new StreamWriter(outputPath);
        else
            textWriter = Console.Out;

        int n = Convert.ToInt32(Console.ReadLine());
        List<string> inputs = new List<string>();

        for (int i = 0; i < n; i++)
        {
            inputs.Add(Console.ReadLine());
        }

        BankOperations bank = new BankOperations();

        foreach (string input in inputs)
        {
            try
            {
                textWriter.WriteLine(bank.ProcessOperation(input));
            }
            catch (Exception ex)
            {
                textWriter.WriteLine(ex.Message);
            }
        }
        

        

        
    }
}
