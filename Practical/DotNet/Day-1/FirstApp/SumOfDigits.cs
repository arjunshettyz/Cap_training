class SumOfDigits
{
    public static void sumOfDigits()
    {
        int num = 123;
        int sum = 0;

        while(num > 0)
        {
            int rem = num % 10;
            sum += rem;
            num = num / 10;
        }

        Console.WriteLine("Sum of Digits is: "+ sum);

    }
}