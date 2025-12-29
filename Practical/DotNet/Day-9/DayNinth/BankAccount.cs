using System;
using System.IO;
public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative", nameof(initialBalance));

        Balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        // Validate numeric range
        if (amount <= 0)
            throw new ArgumentException(
                "Withdrawal amount must be greater than zero",
                nameof(amount));

        // Enforce business rule
        if (amount > Balance)
            throw new InsufficientBalanceException(
                $"Cannot withdraw {amount:C}. Available balance: {Balance:C}");

        Balance -= amount;
    }
}