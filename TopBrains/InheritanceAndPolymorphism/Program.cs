using System;
using System.Globalization;

abstract class Employee
{
    // Polymorphic method
    public abstract decimal GetPay();
}

// HourlyEmployee: pay = rate * hours
class HourlyEmployee : Employee
{
    private decimal rate;
    private decimal hours;

    public HourlyEmployee(decimal rate, decimal hours)
    {
        this.rate = rate;
        this.hours = hours;
    }

    public override decimal GetPay()
    {
        return rate * hours;
    }
}

// SalariedEmployee: pay = monthlySalary
class SalariedEmployee : Employee
{
    private decimal salary;

    public SalariedEmployee(decimal salary)
    {
        this.salary = salary;
    }

    public override decimal GetPay()
    {
        return salary;
    }
}

// CommissionEmployee: pay = baseSalary + commission
class CommissionEmployee : Employee
{
    private decimal commission;
    private decimal baseSalary;

    public CommissionEmployee(decimal commission, decimal baseSalary)
    {
        this.commission = commission;
        this.baseSalary = baseSalary;
    }

    public override decimal GetPay()
    {
        return baseSalary + commission;
    }
}

class Program
{
    public static void Main()
    {
        // Example input
        string[] employees =
        {
            "H 20 8",
            "S 3000",
            "C 500 2000"
        };

        decimal totalPay = ComputeTotalPayroll(employees);

        Console.WriteLine(totalPay.ToString("0.00"));
    }

    public static decimal ComputeTotalPayroll(string[] employees)
    {
        decimal total = 0;

        foreach (string emp in employees)
        {
            string[] parts = emp.Split(' ');
            Employee employee = null;

            if (parts[0] == "H")
            {
                decimal rate = decimal.Parse(parts[1]);
                decimal hours = decimal.Parse(parts[2]);
                employee = new HourlyEmployee(rate, hours);
            }
            else if (parts[0] == "S")
            {
                decimal salary = decimal.Parse(parts[1]);
                employee = new SalariedEmployee(salary);
            }
            else if (parts[0] == "C")
            {
                decimal commission = decimal.Parse(parts[1]);
                decimal baseSalary = decimal.Parse(parts[2]);
                employee = new CommissionEmployee(commission, baseSalary);
            }

            // Polymorphism 
            total += employee.GetPay();
        }

        return Math.Round(total, 2);
    }
}
