using System;

// Object array: array of objects (e.g. Person with Name, Age), display them
class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter count of persons:");
        int n = int.Parse(Console.ReadLine() ?? "0");
        var people = new Person[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Person {i + 1} - Name:");
            string name = Console.ReadLine() ?? "";
            Console.WriteLine($"Person {i + 1} - Age:");
            int age = int.Parse(Console.ReadLine() ?? "0");
            people[i] = new Person { Name = name, Age = age };
        }

        Console.WriteLine("--- Persons ---");
        foreach (var p in people)
            Console.WriteLine($"{p.Name}, {p.Age}");
    }
}
