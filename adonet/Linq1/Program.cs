using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}

class Program
{
    static void Main()
    {
        // Sample Input
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Arun", Department = "IT", Salary = 60000 },
            new Employee { Id = 2, Name = "Meera", Department = "HR", Salary = 45000 },
            new Employee { Id = 3, Name = "John", Department = "IT", Salary = 75000 }
        };

        // Filter salary > 50000 and group by Department
        Dictionary<string, List<Employee>> result = employees
            .Where(e => e.Salary > 50000)
            .GroupBy(e => e.Department)
            .ToDictionary(g => g.Key, g => g.ToList());

        // Print Output
        foreach (var group in result)
        {
            Console.Write(group.Key + " → ");

            Console.WriteLine(string.Join(", ", group.Value.Select(e => e.Name)));
        }
    }
}