using System;

// Delegate declaration
delegate void ErrorDelegate(string message);

class Program
{
    static void Main()
    {
        // Delegate instance using lambda
        ErrorDelegate errorHandler = msg =>
        {
            Console.WriteLine("Error: " + msg);
        };

        // Invoke delegate
        errorHandler("File not found");
    }
}
