using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Creating objects..");

        for (int i = 0; i < 3; i++)
        {
            MyClass obj = new MyClass();
        }

        Console.WriteLine("Forcing garbage collection..");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("Garbage collection completed..");
    }
}

class MyClass
{
    public MyClass()
    {
        Console.WriteLine("MyClass object created");
    }

    ~MyClass()
    {
        Console.WriteLine("MyClass object destroyed");
    }
}
