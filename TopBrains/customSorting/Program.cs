using System;
using System.Collections.Generic;

// Custom sorting: sort a list of objects by custom criteria (e.g. Student by Marks desc, then Age asc)
class Student
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public int Marks { get; set; }
}

class StudentComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x == null || y == null) return 0;
        if (x.Marks != y.Marks) return y.Marks.CompareTo(x.Marks);
        return x.Age.CompareTo(y.Age);
    }
}

class Program
{
    static void Main()
    {
        var list = new List<Student>
        {
            new Student { Name = "Vamsi", Age = 21, Marks = 92 },
            new Student { Name = "Arjun", Age = 20, Marks = 92 },
            new Student { Name = "Sammy", Age = 19, Marks = 90 }
        };

        list.Sort(new StudentComparer());

        foreach (var s in list)
            Console.WriteLine($"Name: {s.Name}, Age: {s.Age}, Marks: {s.Marks}");
    }
}
