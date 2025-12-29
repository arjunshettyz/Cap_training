using System;

class FinanceControlSystem
{
    public static void startApp()
    {
        Console.WriteLine("Welcome to Finance Control System!");

        bool flag = true;
        int balance = 0, count = 0;

        while (flag)
        {
            Console.WriteLine("Choose: \n 1. Loan Eligibility Check \n 2. Income Tax Calculation \n 3. Transaction Entry System \n 4. Access Debit Services \n 5. Access Credit Services \n 6. Exit Program");
            Console.Write("Choose: ");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    {
                        Console.Write("Enter you age: ");
                        int age = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Your Monthly Income: ");
                        int monthlyIncome = Convert.ToInt32(Console.ReadLine());

                        if (age >= 21 && monthlyIncome >= 30000)
                        {
                            Console.WriteLine("Congratulation! You are Eligible to take loan.");
                        }
                        else
                        {
                            Console.WriteLine("Oops!, You are not Eligible to take loan.");
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter you Annual Income: ");
                        int annualIncome = Convert.ToInt32(Console.ReadLine());
                        double taxAmount = 0;

                        if (annualIncome <= 250000)
                        {
                            Console.WriteLine($"Tax You have to pay: 0%, equivalant to ₹{taxAmount}");
                        }
                        else if (annualIncome > 250000 && annualIncome <= 500000)
                        {
                            taxAmount = annualIncome / 100 * 5;
                            Console.WriteLine($"Tax You have to pay: 5%, equivalant to ₹{taxAmount}");
                        }
                        else if (annualIncome > 500000 && annualIncome <= 1000000)
                        {
                            taxAmount = annualIncome / 100 * 20;
                            Console.WriteLine($"Tax You have to pay: 20%, equivalant to ₹{taxAmount}");
                        }
                        else
                        {
                            taxAmount = annualIncome / 100 * 30;
                            Console.WriteLine($"Tax You have to pay: 30%, equivalant to ₹{taxAmount}");
                        }
                        break;
                    }

                case 3:
                    {
                        Console.Write("Enter Amount: ");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        if (amount <= 0)
                        {
                            Console.WriteLine("Invalid Ammount!, Amount Should be in Positive.");
                            break;
                        }
                        if (count == 5)
                        {
                            Console.WriteLine("Oops! you reached today's limit");
                            break;
                        }
                        count++;
                        balance += amount;
                        Console.WriteLine($"Transaction Successfull, Your Current Balance: {balance}");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Welcome To Debits Services!");
                        Console.WriteLine("Choose: \n 1. ATM Withdrawal Limit Validation \n 2. EMI Burden Evaluation \n 3. Transaction-Based Daily Spending Calculator \n 4. Minimum Balance Compliance Check \n 5. Exit");
                        Console.Write("Choose: ");
                        int debitChoice = Convert.ToInt32(Console.ReadLine());
                        
                        switch (debitChoice)
                        {
                            case 1:
                                {
                                    Console.Write("Enter Amount: ");
                                    int amount = Convert.ToInt32(Console.ReadLine());

                                    if (amount < 0)
                                    {
                                        Console.WriteLine("Amount Should not be Negative!");
                                        break;
                                    }

                                    if (amount <= balance)
                                    {
                                        balance = Debit.ATMWithdrawalLimitValidation(balance, amount);

                                    }
                                    break;
                                }
                            case 2:
                                {
                                    Console.Write("Enter Monthly Income: ");
                                    int monthlyIncome = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Enter EMI Amount: ");
                                    int EMIAmount = Convert.ToInt32(Console.ReadLine());

                                    Debit.EMIBurdenEvaluation(monthlyIncome, EMIAmount);
                                    break;
                                }
                            case 3:
                                {
                                    balance = Debit.transactionBasedDailySpendingCalculator(balance);
                                    break;
                                }
                            case 4:
                                {
                                    Debit.MinimumBalanceComplianceCheck();
                                    break;
                                }
                            case 5:
                                {
                                    break;
                                }
                        }
                        
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Welcome To Credit Services!");
                        Console.WriteLine("Choose: \n 1. Net Salary Credit Calculation \n 2. Fixed Deposit Maturity Calculation \n 3. Credit Card Reward Points Evaluation \n 4. Employee Bonus Eligibility Check \n 5. Exit");
                        Console.Write("Choose: ");
                        int creditChoice = Convert.ToInt32(Console.ReadLine());
                        
                        switch (creditChoice)
                        {
                            case 1:
                                {
                                    Credit.NetSalaryCreditCalculation();
                                    break;
                                }
                            case 2:
                                {
                                    Credit.FixedDepositMaturityCalculation();
                                    break;
                                }
                            case 3:
                                {
                                    Credit.CreditCardRewardPointsEvaluation();
                                    break;
                                }
                            case 4:
                                {
                                    Credit.EmployeeBonusEligibilityCheck();
                                    break;
                                }
                            case 5:
                                {                                
                                    break;
                                }
                        }
                        

                        break;
                    }
                case 6:
                    {
                        flag = false;
                        break;
                    }
            }
        }
    }
}