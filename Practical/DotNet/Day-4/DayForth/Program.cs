// See https://aka.ms/new-console-template for more information

class Program
{
    public static void Main()
    {
        // Console.WriteLine("Hello, World!");

        // Product p = new Product
        // {
        //     Name = "Laptop",
        //     Price = 50000
        // };


        // Employee emp = new Employee();
        // emp.Salary = 50000;   // valid
        // emp.Salary = -2000;   // ignored
        // Console.WriteLine(emp.Salary);

        // Assignment  -- Student Profile System
        // Student s = new Student();
        // s.Name = "Aryan";
        // s.Age = 22;
        // s.Marks = 91;
        // s.Password = "Aryan@123";


        // Console.WriteLine("--------- Welcome to Student Profile System ----------");
        // Console.WriteLine("Name: " + s.Name);
        // Console.WriteLine("Age: " + s.Age);
        // Console.WriteLine("Marks: " + s.Marks);
        // Console.WriteLine("Result: " + s.GetResult);
        // Console.WriteLine("Password: " + s.Password);                // give compile time error, Because Password Property is in Write-Only Mode. (Allow Only write)


        // Library Management System Using Indexer
        Library books = new Library();
        books[101] = "The Apple";
        books[102] = "The Mango";
        books[103] = "The Banana";

        Console.WriteLine(books[101]);
        Console.WriteLine(books["The Mango"]);
        Console.WriteLine(books["The Banana"]);


    }
}
