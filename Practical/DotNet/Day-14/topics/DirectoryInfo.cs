using System;
using System.IO;

class Program
{
    static void Main()
    {
        DirectoryInfo dir = new DirectoryInfo("Logs");

        if (!dir.Exists)
        {
            dir.Create();
        }

        Console.WriteLine("Directory Name: " + dir.Name);
        Console.WriteLine("Created On: " + dir.CreationTime);
        Console.WriteLine("Full Path: " + dir.FullName);
    }
}
