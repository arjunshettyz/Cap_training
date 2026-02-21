using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

// C# record for Student
public record Student(string Name, int Score);

class Program
{
    static void Main()
    {
        // Input format:
        // Example:
        // Alice:90 Bob:75 John:90 Mary:60
        // 80

        string[] items = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int minScore = int.Parse(Console.ReadLine());

        string json = BuildStudentJson(items, minScore);

        Console.WriteLine(json);
    }

    static string BuildStudentJson(string[] items, int minScore)
    {
        List<Student> students = new List<Student>();

        // Parse items into Student records
        foreach (var item in items)
        {
            string[] parts = item.Split(':');
            string name = parts[0];
            int score = int.Parse(parts[1]);

            students.Add(new Student(name, score));
        }

        // Filter, Sort, Serialize
        var filteredSorted = students
            .Where(s => s.Score >= minScore)
            .OrderByDescending(s => s.Score)
            .ThenBy(s => s.Name)
            .ToList();

        string json = JsonSerializer.Serialize(filteredSorted);

        return json;
    }
}