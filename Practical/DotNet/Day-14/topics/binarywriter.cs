using System;
using System.IO;

class User
{
    public int Id;
    public string? Name;
}

class Program
{
    static void Main()
    {
        User user = new User { Id = 2, Name = "Bob" };

        using (BinaryWriter writer = new BinaryWriter(File.Open("user1.bin", FileMode.Create)))
        {
            writer.Write(user.Id);
            writer.Write(user.Name);
        }

        Console.WriteLine("Binary user data saved.");
        
    }
}
