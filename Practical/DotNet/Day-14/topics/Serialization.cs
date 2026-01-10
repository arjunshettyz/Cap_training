using System;
using System.IO;
using System.Text.Json;

class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

class Program
{
    static void Main()
    {
          User user = new User { Id = 1, Name = "Alice" };

        string json = JsonSerializer.Serialize(user);

        File.WriteAllText("user.json", json);

        Console.WriteLine("User serialized successfully.");

    }
}
