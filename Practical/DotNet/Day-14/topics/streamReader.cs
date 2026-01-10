using System;
using System.IO;

public class User
{
    public int Id;
    public string Name;
}

class Program
{
    static void Main()
    {
        
        User user = new User
        {
            Id = 1,
            Name = "bob"
        };

        
        using (StreamReader reader = new StreamReader("user.txt"))
        {
            user.Id = int.Parse(reader.ReadLine());
            user.Name = reader.ReadLine();
        }

        Console.WriteLine($"User Loaded: {user.Id}, {user.Name}");
    }
}