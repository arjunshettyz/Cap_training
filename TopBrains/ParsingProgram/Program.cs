using System;

// Parsing program: parse input (e.g. "Name:John,Age:25" or CSV)
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter line to parse (format: Name:John,Age:25):");
        string input = Console.ReadLine() ?? "";

        string name = "";
        int age = 0;
        foreach (string part in input.Split(','))
        {
            string[] kv = part.Split(':', 2, StringSplitOptions.RemoveEmptyEntries);
            if (kv.Length != 2) continue;
            string key = kv[0].Trim();
            string value = kv[1].Trim();
            if (key.Equals("Name", StringComparison.OrdinalIgnoreCase)) name = value;
            if (key.Equals("Age", StringComparison.OrdinalIgnoreCase)) int.TryParse(value, out age);
        }

        Console.WriteLine($"Parsed - Name: {name}, Age: {age}");
    }
}
