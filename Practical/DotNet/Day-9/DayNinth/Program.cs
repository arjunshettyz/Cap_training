// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
// using System.Exception;
class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to Day 9!");
        Console.WriteLine("--------- Exception Handling ----------");
        // int a = 8;
        // int b = 0;

        // try
        // {
        //     int res = a / b;

        // }catch(Exception ex)
        // {
        //     Console.WriteLine("Error Occured: "+ ex.Message);
        // }

        // try
        // {
        //     Console.Write("Enter withdrawal amount: ");
        //     decimal amount = decimal.Parse(Console.ReadLine());

        //     int serviceCharge = 100;
        //     int devisionCheck = serviceCharge / int.Parse("1");

        //     string data = File.ReadAllText("account.txt");

        //     BankAccount account = new BankAccount();
        //     account.Withdraw(amount);

        //     Console.WriteLine("Withdrawal Successful.");

        // }catch(FormatException ex)
        // {
        //     LogException(ex);
        //     Console.WriteLine("Invalid Input Format.");
        // }catch(DivideByZeroException ex)
        // {
        //     LogException(ex);
        //     Console.WriteLine("Arthmetic Error Occurred.");
        // }
        // catch(FileNotFoundException ex)
        // {
        //     LogException(ex);
        //     Console.WriteLine("Required file not found.");
        // }catch(InsufficientBalanceException ex)
        // {
        //     LogException(ex);
        //     Console.WriteLine(ex.Message);
        // }catch(Exception ex)
        // {
        //     LogException(ex);
        //     Console.WriteLine("An Unexpected Error Occurred.");
        // }
        // finally
        // {
        //     Console.WriteLine("Transaction attempt completed!");
        // }


        // Another Program
        // FileStream file = null;
        // try
        // {
        //     file = new FileStream("data.txt", FileMode.Open);
        //     int data = file.ReadByte();
        // }catch(FileNotFoundException ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }


        // another program
        // try
        // {
        //     // Simulate database operation
        //     throw new SqlException("Connection failed");
        // }
        // catch (SqlException ex)
        // {
        //     // Wrap low-level exception into higher-level exception
        //     throw new Exception("Database operation failed in Service Layer", ex);
        // }



        // another program
        // try
        // {
        //     try
        //     {
        //         File.ReadAllText("transactions.txt");
        //     }
        //     catch (IOException ioEx)     // low level exception (Technical Layer)
        //     {
        //         throw new ApplicationException("Unable to load transaction data", ioEx);  // Exception Wrapping (Business layer)
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine("Message: " + ex.Message);
        //     Console.WriteLine("Root Cause: " + ex.InnerException.Message);
        // }


        //Another Program
        BankAccount account = new BankAccount(5000);
        account.Withdraw(6000);




    }
    // static void LogException(Exception ex)
    // {
    //     File.AppendAllText("error.log", DateTime.Now + " | " + ex.GetType().Name + " | " + ex.Message + Environment.NewLine);
    // }
}