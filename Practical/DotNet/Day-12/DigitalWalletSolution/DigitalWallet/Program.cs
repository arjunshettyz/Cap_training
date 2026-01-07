using System;
using DigitalWallet.Core.Services; // DLL namespace

namespace DigitalWallet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console App Started");

            AppInfoService appInfo = new AppInfoService();

            Console.WriteLine(appInfo.GetAppName());
            Console.WriteLine(appInfo.GetVersion());

            Console.WriteLine($"Arguments Count: {args.Length}");
        }
    }
}
