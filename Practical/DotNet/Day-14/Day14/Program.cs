using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class User
{
    public int Id;
    public string? Name;
}


class Program
{
    static void Main()
    {
          User user = new User { 
            Id = 1,
            Name = "Alice" 
            };
        XmlSerializer serializer = new XmlSerializer(typeof(User));
        using (FileStream fs = new FileStream("user.xml", FileMode.Create))
        {
            serializer.Serialize(fs, user);
        }

        Console.WriteLine("XML Serialized");
    }
}
