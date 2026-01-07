using System;

class Program
{
    static void Main()
    {
        Action<string> logActivity = message =>
        {
            Console.WriteLine("Log Entry: " + message);
        };

        logActivity("User logged in at 10:30 AM");
    }
}
