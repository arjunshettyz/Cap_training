class Practice
{

    // for Each Example
    public static void forEachEample(string name)
    {
        foreach(char ch in name)
        {
            Console.Write(ch+ " ");
        }
        Console.WriteLine();
    }

    // param Example
    public static void sum(params int[] nums)
    {
        int sum = 0;

        foreach(int num in nums)
        {
            sum += num;
        }

        Console.WriteLine("Sum of Parameter: "+ sum);
    }


    // Reference Example

    public static void decreaseByTen(ref int a)
    {
        a = a - 10;
    }

    // Out Example
    public static void Divide(int a, int b, out int quotient, out int remainder)
    {
        quotient = a / b;
        remainder = a % b;
    }

    public static void GetResult(int marks, out string grade)
    {
        if (marks >= 60)
            grade = "Pass";
        else
            grade = "Fail";
    }

    // "In" example
    public static void Show(in int number)
    {
        Console.WriteLine(number);

        // number = number + 10;   // Not allowed
    }

    // Multiple Params Example     // multiple params not allowed

    // public static void MultipleParams(params int[]nums1, params int[] nums2)
    // {
        
    // }

    // combine default and prams
    public static void DefaultThenParams(int a, int b = 10, params int[] nums)
    {
        Console.WriteLine("A: " + a);
        Console.WriteLine("B: " + b);
        int sum = 0;

        foreach(int num in nums){
            sum += num;
        }
        Console.WriteLine("Sum: "+ sum);
    }



    // this method give error because "param" needs to be at last

    // public static void ParamsThenDefault(int a, params int[] nums, int b = 10)
    // {
    //     Console.WriteLine("A: " + a);
    //     Console.WriteLine("B: " + b);
    //     int sum = 0;

    //     foreach(int num in nums){
    //         sum += num;
    //     }
    //     Console.WriteLine("Sum: "+ sum);
    // }

    public static void ParamsArray(params int[] nums)
    {
        int sum = 0;
        foreach(int num in nums)
        {
            sum += num;
        }

        Console.WriteLine("Sum: " + sum);
    }

    // Local Method Example
    public static void Process()
    {
        string status = "Processing...";

        void PrintMsg()
        {
            Console.WriteLine(status);
        }

        PrintMsg();
    }
}