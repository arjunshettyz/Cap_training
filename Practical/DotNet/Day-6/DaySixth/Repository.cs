class Repository<T> where T: class
{
    public T Data;

    public T PrintData<T>(T Data)
    {
        Console.WriteLine(Data);
        return Data;
    }
}