using System;

abstract class LibraryItem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int ItemID { get; set; }

    public LibraryItem()                  // Default Constructor
    {
        
    }

    public LibraryItem(string title, string author, int itemId)
    {
        Title = title;
        Author = author;
        ItemID = itemId;
    }


    public abstract void DisplayDetails();
    public abstract double CalculateLateFee(int days);
}


