using System;
using System.IO;




internal class Program
{
    private static void Main(string[] args)
    {


        // string path = "data.txt";

// File.WriteAllText(path, "File I/O Example in C#");

// Console.WriteLine("Data written to file.");
       
        using (StreamWriter writer = new StreamWriter("log.txt"))
        {
            writer.WriteLine("Application Started");
            writer.WriteLine("Processing Data");
            writer.WriteLine("Application Ended");
        }

        using (StreamReader reader = new StreamReader("user.txt"))
        {
            string line;
          
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}