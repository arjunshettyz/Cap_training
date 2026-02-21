using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = "log.txt";
        string outputFile = "error.txt";

        // Read all lines from log.txt
        string[] lines = File.ReadAllLines(inputFile);

        // Write only ERROR lines to error.txt
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (string line in lines)
            {
                if (line.Contains("ERROR"))
                {
                    writer.WriteLine(line);
                }
            }
        }

        Console.WriteLine("ERROR logs extracted to error.txt");
    }
}