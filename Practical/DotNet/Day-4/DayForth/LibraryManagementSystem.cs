class Library
{
    // Example of Indexer and Indexer Overloading
    private Dictionary<int, string> books = new Dictionary<int, string>();

    public string this[int id]
    {
        get { return books[id]; }
        set { books[id] = value; }
    }

    public string this[string title]
    {
        get
        {
            return books.FirstOrDefault(e => e.Value == title).Value;
        }
    }
}