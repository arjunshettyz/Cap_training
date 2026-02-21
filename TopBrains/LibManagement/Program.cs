using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // In-memory storage using Generic Collection
    static List<dynamic> books = new List<dynamic>();
    static int nextId = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== Library Management System =====");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");
            Console.WriteLine("3. Exit");
            Console.Write("Select option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AdminMenu();
                    break;
                case 2:
                    UserMenu();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    // ================= ADMIN MENU =================
    static void AdminMenu()
    {
        Console.WriteLine("\n--- Admin Menu ---");
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. Update Book");
        Console.WriteLine("3. Delete Book");
        Console.WriteLine("4. View All Books");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1: AddBook(); break;
            case 2: UpdateBook(); break;
            case 3: DeleteBook(); break;
            case 4: ViewAllBooks(); break;
        }
    }

    // ================= USER MENU =================
    static void UserMenu()
    {
        Console.WriteLine("\n--- User Menu ---");
        Console.WriteLine("1. Browse Books");
        Console.WriteLine("2. Search by Name");
        Console.WriteLine("3. Search by Publisher");
        Console.WriteLine("4. Highest Price Book");
        Console.WriteLine("5. Lowest Price Book");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1: ViewAllBooks(); break;
            case 2: SearchByName(); break;
            case 3: SearchByPublisher(); break;
            case 4: HighestPriceBook(); break;
            case 5: LowestPriceBook(); break;
        }
    }

    // ================= CRUD OPERATIONS =================

    static void AddBook()
    {
        dynamic book = new System.Dynamic.ExpandoObject();

        book.Id = nextId++;

        Console.Write("Enter Book Name: ");
        book.Name = Console.ReadLine();

        Console.Write("Enter Publisher: ");
        book.Publisher = Console.ReadLine();

        Console.Write("Enter Price: ");
        book.Price = decimal.Parse(Console.ReadLine());

        books.Add(book);

        Console.WriteLine("Book Added Successfully");
    }

    static void UpdateBook()
    {
        Console.Write("Enter Book ID to update: ");
        int id = int.Parse(Console.ReadLine());

        var book = books.FirstOrDefault(b => b.Id == id);

        if (book != null)
        {
            Console.Write("Enter New Name: ");
            book.Name = Console.ReadLine();

            Console.Write("Enter New Publisher: ");
            book.Publisher = Console.ReadLine();

            Console.Write("Enter New Price: ");
            book.Price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Book Updated");
        }
        else
        {
            Console.WriteLine("Book Not Found");
        }
    }

    static void DeleteBook()
    {
        Console.Write("Enter Book ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        var book = books.FirstOrDefault(b => b.Id == id);

        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine("Book Deleted");
        }
        else
        {
            Console.WriteLine("Book Not Found");
        }
    }

    static void ViewAllBooks()
    {
        Console.WriteLine("\n--- Book List ---");

        if (books.Count == 0)
        {
            Console.WriteLine("No books available");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.Id}, Name: {book.Name}, Publisher: {book.Publisher}, Price: {book.Price}");
        }
    }

    // ================= SEARCH =================

    static void SearchByName()
    {
        Console.Write("Enter Book Name: ");
        string name = Console.ReadLine().ToLower();

        var result = books.Where(b => b.Name.ToLower().Contains(name));

        foreach (var book in result)
        {
            Console.WriteLine($"ID: {book.Id}, Name: {book.Name}, Publisher: {book.Publisher}, Price: {book.Price}");
        }
    }

    static void SearchByPublisher()
    {
        Console.Write("Enter Publisher: ");
        string publisher = Console.ReadLine().ToLower();

        var result = books.Where(b => b.Publisher.ToLower().Contains(publisher));

        foreach (var book in result)
        {
            Console.WriteLine($"ID: {book.Id}, Name: {book.Name}, Publisher: {book.Publisher}, Price: {book.Price}");
        }
    }

    // ================= HIGHEST & LOWEST =================

    static void HighestPriceBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available");
            return;
        }

        var book = books.OrderByDescending(b => b.Price).First();

        Console.WriteLine($"Highest Price Book: {book.Name}, Price: {book.Price}");
    }

    static void LowestPriceBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available");
            return;
        }

        var book = books.OrderBy(b => b.Price).First();

        Console.WriteLine($"Lowest Price Book: {book.Name}, Price: {book.Price}");
    }
}