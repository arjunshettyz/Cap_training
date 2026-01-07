using System;

class Downloader
{
    // Step 1: Delegate declaration
    public delegate void DownloadDelegate();

    // Step 2: Event declaration (SAFE design)
    public event DownloadDelegate DownloadCompleted;

    // Step 3: Method that raises the event
    public void CompleteDownload()
    {
        Console.WriteLine("Download completed");
        DownloadCompleted?.Invoke();
    }
}

class Program
{
    static void Main()
    {
        Downloader d = new Downloader();

        // Step 4: Subscribe to event using lambda
        d.DownloadCompleted += () =>
        {
            Console.WriteLine("Notification: Download completion handled");
        };

        // Step 5: Trigger download completion
        d.CompleteDownload();
    }
}
