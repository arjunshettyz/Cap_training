using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var students = new[]
        {
            new Student { Name = "Arjun", Marks = 75 },
            new Student { Name = "shetty", Marks = 45 },
            new Student { Name = "akshay", Marks = 65 }
        };

        var result = students.Select(
            s => new
        {
            s.Name,
            Grade = s.Marks > 60 ? "Pass" : "Fail"
        });

        foreach (var r in result)
        {
            Console.WriteLine(r.Name + " : " + r.Grade);
        }
    }
}

class Student
{
    public required string Name { get; set; }
    public int Marks { get; set; }
}
