using Microsoft.VisualBasic;

namespace BankingSystem
{    
    class BankAccount
    {
        public string AccountNumber {get; private set;}
        public decimal Balance {get; private set;}

        public BankAccount(string accountNumber, decimal initialBalance)
        {            
            try
            {
                if (accountNumber == null || accountNumber == "" || accountNumber == " ")
                {
                    throw new Exception("Error: Invalid Account Number.");
                }
                if(initialBalance < 0)
                {
                    throw new Exception("Initial Balance Can't be in Negative");
                }
                AccountNumber = accountNumber;
                Balance = initialBalance;

            }
            catch(Exception ex)
            {
                LogException(ex);
                Console.WriteLine("Message: " + ex);
            }
            
        }
        public void Withdraw(decimal amount)
        {
            try
            {
                try
                {
                    if (amount <= 0)
                    {
                        throw new Exception("Amount Must be Greater Than Zero.");
                    }
                }catch(Exception ex)
                {
                    throw new BankOperationException(ex.ToString());
                }

                if(amount > Balance)
                {
                    throw new InsufficientBalanceException("Error: Insufficient balance for withdraw!");
                }
                Balance -= amount;
                Console.WriteLine($"Amount Withdrawal Successful. Current Balance: {Balance:F2}");

            }catch(BankOperationException ex)
            {
                LogException(ex);
                Console.WriteLine("Message: " + ex);
                Console.WriteLine("Root Cause: " + ex.InnerException.Message);
            }
            catch(InsufficientBalanceException ex)
            {
                LogException(ex);
                Console.WriteLine("Message: " + ex);
            }
            catch(Exception ex)
            {
                LogException(ex);
                Console.WriteLine("Message: " + ex);
            }
        }
        private void LogException(Exception ex)
        {
            File.AppendAllText("error.log", DateTime.Now + " | " + AccountNumber + " | " + ex.GetType().Name + " | " + ex.Message + Environment.NewLine);
        }
    }
}