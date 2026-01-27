using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public string Grade { get; set; }
    public int Marks { get; set; }
}

class Program
{
    static void Main()
    {
        // Create three objects
        List<Student> students = new List<Student>
        {
            new Student { Name = "Arjun", Grade = "A", Marks = 75 },
            new Student { Name = "Rohit", Grade = "B", Marks = 55 },
            new Student { Name = "Sneha", Grade = "A", Marks = 90 }
        };

        // LINQ query
        var result = students.Select(s => new
        {
            s.Name,
            Result = s.Marks > 60 ? "Pass" : "Fail"
        });

        // Print result
        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name} - {item.Result}");
        }

        // Type of result
        Console.WriteLine(result.GetType());
    }
}
