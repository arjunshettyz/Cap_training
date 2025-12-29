// See https://aka.ms/new-console-template for more information
using System;
using BankingSystem;
class Program
{
    public static void Main()
    {
        Console.WriteLine("-----Welcome to Secure Banking Withdrawal System!------");
        BankAccount account = new BankAccount("1234567890", 1000);
        account.Withdraw(500);
        

    }
}