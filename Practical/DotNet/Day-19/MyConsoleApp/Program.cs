using System;
using System.Reflection;

class Program
{
    public static void Main()
    {
        B b = new B();
        Type t = typeof(B);

        Console.WriteLine("Class Name: " + t.Name);
        Console.WriteLine("Full Name: " + t.FullName);
        Console.WriteLine();

        MethodInfo[] methods = t.GetMethods();

        foreach (MethodInfo m in methods)
        {
            Console.WriteLine($"{m.Name} - Return Type: {m.ReturnType}");
        }

        Console.WriteLine();
        Console.WriteLine("Total number of methods: " + methods.Length);
    }
}
