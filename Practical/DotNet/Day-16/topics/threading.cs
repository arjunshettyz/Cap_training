// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static int counter = 0;
    static object lockobj = new object();

    static void Increment()
    {
        for (int i = 0; i < 10000; i++)
        {
            lock (lockobj)
            {
                counter++;
            }
        }
    }

    static void Main()
    {
        Process currentProcess = Process.GetCurrentProcess();
        Console.WriteLine("Current process ID: " + currentProcess.Id);
        Console.WriteLine("Process Name : " + currentProcess.ProcessName);
        Console.WriteLine("Process StartTime : " + currentProcess.StartTime);
        Console.WriteLine("Process Threads : " + currentProcess.Threads);
        Console.WriteLine("Process Memory Usage : " + currentProcess.WorkingSet64);
        Console.WriteLine("Process usageTime : " + currentProcess.TotalProcessorTime);
        // Thread worker = new Thread(DoWork);

        // Start the thread
        // worker.Start();

        // Console.WriteLine("Main thread continues...");

        // // Optional: Wait for worker thread to finish
        // worker.Join();
        // Console.WriteLine("Main thread finished");

        // static void DoWork()
        // {
        //     for (int i = 1; i <= 5; i++)
        //     {
        //         Console.WriteLine("Worker thread: " + i);
        //         Thread.Sleep(500); // Simulate work
        //     }
        // }
        // Process.Start("notepad.exe");
        // Process.Start("cmd.exe");

        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();

        Console.WriteLine("Final Counter Value: " + counter);
    }
}
