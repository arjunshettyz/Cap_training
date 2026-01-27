using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    static async Task<int> GetDataAsync()
    {
        await Task.Delay(1000);
        return 100;
    }
    public static async Task Main()
    {
//         Thread thread=new Thread(new ParameterizedThreadStart( PrintMessage));
// thread.Start("Hello from thread");
    Thread Worker=new Thread(Dowork);
        // Worker.Start();
        // Console.WriteLine("Main method starts ");
        // Parallel.For(0, 5, i =>
        // {
        //     Console.WriteLine($"Processing item {i}");
        // });
        int[] nums={1,2,3,4,5,6,7,8,9,10};
        int sum=0;
        // Parallel.For(0, nums.Length, i =>
        // {
        //     sum+=nums[i];
        // });
        // // Console.WriteLine(sum);
        // Parallel.For(0,nums.Length,
        // () => 0, (i, loopState, localSum) =>
        // {
        //     return localSum+nums[i];
        // },
        // localSum =>
        // {
        //     Interlocked.Add(ref sum,localSum);
        // });
        // Console.WriteLine( "Sum : "+sum);


        //---------------------------->async -await-------------------------------------->

        // Console.WriteLine(await GetDataAsync());

        //---------------------------->Aysn-demo<------------------------------
        Console.WriteLine("Start reading File:");
        string content =await File.ReadAllTextAsync("data.txt");
        Console.WriteLine("File content:"+content);
        Console.WriteLine("End of program");


    }

    static  void Dowork()
    {
        for(int i = 0; i <= 5; i++)
        {
            Console.WriteLine("Woker thread: "+i);
            Thread.Sleep(2000);
        }
    }
    static void PrintMessage(Object message)
    {
        Console.WriteLine(message);
    }

}