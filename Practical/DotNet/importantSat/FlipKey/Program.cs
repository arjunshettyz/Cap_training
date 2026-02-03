using System;

class Program
{
    public string CleanseAndInvert(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length < 6)
            return "";

        foreach (char ch in input)
        {
            if (!char.IsLetter(ch))
                return "";
        }

        input = input.ToLower();

        string filtered = "";
        foreach (char ch in input)
        {
            if (((int)ch) % 2 != 0) 
            {
                filtered += ch;
            }
        }

        char[] arr = filtered.ToCharArray();
        Array.Reverse(arr);

        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
            {
                arr[i] = char.ToUpper(arr[i]);
            }
        }

        return new string(arr);
    }

    static void Main(string[] args)
    {
        Program obj = new Program();

        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        string result = obj.CleanseAndInvert(input);

        if (result == "")
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("The generated key is - " + result);
        }
    }
}
