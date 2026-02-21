using System;

// Event-driven phone call notification: event when call arrives, subscribers get notified
class PhoneCallNotifier
{
    public event Action<string, string> IncomingCall;

    public void SimulateIncomingCall(string callerName, string callerNumber)
    {
        Console.WriteLine("[System] Incoming call received...");
        IncomingCall?.Invoke(callerName, callerNumber);
    }
}

class Program
{
    static void Main()
    {
        var notifier = new PhoneCallNotifier();

        notifier.IncomingCall += (name, number) =>
        {
            Console.WriteLine($"NOTIFICATION: Incoming call from {name} ({number})");
        };

        notifier.IncomingCall += (name, number) =>
        {
            Console.WriteLine($"[Log] Call logged at {DateTime.Now:HH:mm:ss}");
        };

        Console.WriteLine("Enter caller name:");
        string name = Console.ReadLine() ?? "Unknown";
        Console.WriteLine("Enter caller number:");
        string number = Console.ReadLine() ?? "";

        notifier.SimulateIncomingCall(name, number);
    }
}
