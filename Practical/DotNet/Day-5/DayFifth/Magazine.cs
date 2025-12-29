class Magazine : LibraryItem
{
    public Magazine(string title, string author, int bookId) : base(title, author, bookId)
    {

    }

    public Magazine()
    {
        
    }
    public override void DisplayDetails()
    {
        Console.WriteLine("----- Magazine Details -----");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Item ID: {ItemID}");
    }
    public override double CalculateLateFee(int days)
    {
        return days * 0.5;
    }
}

partial class LibraryAnalytics
{
    public static void ShowAnalytics()
    {
        Console.WriteLine($"Total Borrowed Item: {TotalItemsBorrowed}");
    }
}
