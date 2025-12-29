class Book : LibraryItem, IReservable, INotifiable
{
    public Book(string title, string author, int bookId) : base(title, author, bookId)
    {
        
    }

    public Book()
    {
        
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("----- Book Details -----");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Item ID: {ItemID}");
    }
    public override double CalculateLateFee(int days)
    {
        return days * 1.0;
    }
    void IReservable.ReserveItem()
    {
        Console.WriteLine("Reservation successful.");
    }

    void INotifiable.SendNotification(string message)
    {
        Console.WriteLine("Notification message sent: " + message);
    }
}