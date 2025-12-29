// See https://aka.ms/new-console-template for more information
using LibrarySystem;
using ItemAlias = LibrarySystem.Items;
class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to Day-5 Capgemini training!");

        Console.WriteLine("*****Welcome to Library Management System******");
        Book book = new Book
        {
            Title = "JAVA",
            Author = "Aryan",
            ItemID = 101
        };
        Magazine magazine = new Magazine
        {
            Title = "Rich Mindset",
            Author = "Robert C.",
            ItemID = 202
        };
        book.DisplayDetails();
        Console.WriteLine("Late Fee for 3 days: " + book.CalculateLateFee(3));
        magazine.DisplayDetails();
        Console.WriteLine("Late Fee for 3 days: " + magazine.CalculateLateFee(3));


        List<LibraryItem> store = new List<LibraryItem>();
        store.Add(book);
        store.Add(magazine);
        store.Add(new Book("The Apple", "Mohit", 103));
        store.Add(new Magazine("The Orange", "Ankit", 104));

        foreach (LibraryItem item in store)
        {
            Console.WriteLine("Method selection happens at runtime");
            item.DisplayDetails();
        }

        // book.ReserveItem();    // it will give error Because of Explicit Interface Implementation
        // book.SendNotification("Your book has been reserved.");           // Same Because of Explicit Interface Implementation

        // EXPLICIT INTERFACE CALLS
        IReservable reservableBook = book;
        INotifiable notifiableBook = book;

        reservableBook.ReserveItem();
        notifiableBook.SendNotification("Your reserved book is ready for pickup.\n");


        ItemAlias.Book book2 = new ItemAlias.Book();                   // accessed by Alias Namespace
        LibrarySystem.Items.Magazine magazine2 = new LibrarySystem.Items.Magazine();       // Without Alias

        book2.Show();
        magazine2.Show();

        LibrarySystem.Users.Member member1 = new LibrarySystem.Users.Member { Name = "Alice", Role = UserRole.Member };
        LibrarySystem.Users.Member librarian1 = new LibrarySystem.Users.Member { Name = "Bob", Role = UserRole.Librarian };
        member1.ShowRole();
        librarian1.ShowRole();

        Console.WriteLine("Thanks For Choosing Our Library Services...");

    }
}
