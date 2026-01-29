using System;
using System.Collections.Generic;

class Student{
    public string Name;
    public int Age, Marks;
    public Student(string n, int a, int m)
    {
        Name = n; Age = a; Marks = m;
    }
}
class StudentComparer : IComparer<Student>{
    public int Compare(Student? x, Student? y)
    {
        if (x == null || y == null) return 0;

        if (x.Marks != y.Marks)
            return y.Marks - x.Marks;
        return x.Age - y.Age;
    }
}
class Program{
    static void Main(){
        List<Student> list = new List<Student>(){
            new Student("Vamsi",21,92),
            new Student("Arjun",20,92),
            new Student("Sammy",19,90)
        };

        list.Sort(new StudentComparer());

        foreach (var s in list)
            Console.WriteLine("Name: "+s.Name + ", "+"Age: "+ + s.Age + ", " + "Name: "+s.Marks);
    }
}
