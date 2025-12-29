using System;
class Credit
{
    public static void NetSalaryCreditCalculation()
    {
        Console.Write("Enter the Gross Salary: ");
        int grossSalary = Convert.ToInt32(Console.ReadLine());

        int netSalary = grossSalary / 100 * 10;
        Console.WriteLine($"Net salary credited: ₹{netSalary}");

    }

    public static void FixedDepositMaturityCalculation()
    {
        Console.Write("Enter Principle amount: ");
        int principleAmount = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Rate of Interest: ");
        int rate = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Time in Month: ");
        double time = Convert.ToDouble(Console.ReadLine());

        double simpleInterest = principleAmount * rate * time / 100;
        double MaturityAmount = principleAmount + simpleInterest;

        Console.WriteLine($"Fixed Deposit maturity amount: ₹{MaturityAmount}");

    }

    public static void CreditCardRewardPointsEvaluation()
    {
        Console.Write("Enter total credit card spending amount: ");
        int spendingAmount = Convert.ToInt32(Console.ReadLine());

        int reward = spendingAmount / 100;

        Console.WriteLine($"Reward points earned: {reward}");

    }

    public static void EmployeeBonusEligibilityCheck()
    {
        Console.Write("Enter Annual Salary: ");
        int annualSalary = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Years of service: ");
        int yearOfService = Convert.ToInt32(Console.ReadLine());

        if(annualSalary >= 500000 && yearOfService >= 3)
        {
            Console.WriteLine("Employee is eligible for bonus.");

        }
        else
        {
            Console.WriteLine("Employee is not eligible for bonus.");
            
        }

    }
}