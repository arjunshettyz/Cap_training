using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Neha", Salary = 50000 },
            new Employee { Name = "Amit", Salary = 70000 },
            new Employee { Name = "Ravi", Salary = 60000 }
        };

        var sortedBySalary = employees.OrderBy(e => e.Salary);

        Console.WriteLine("Employees sorted by salary:");
        foreach (var e in sortedBySalary)
        {
            Console.WriteLine(e.Name + " - " + e.Salary);
        }
    }
}

class Employee
{
    public required string Name { get; set; }
    public int Salary { get; set; }
}
