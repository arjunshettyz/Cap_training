using System;

class Program
{
    static void Main()
    {
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        int count = 0;

        for (int x = m; x <= n; x++)
        {
            if (x > 1 && IsPrime(x))
                continue;

            int s = SumOfDigits(x);
            int sqSum = SumOfDigits(x * x);

            if (sqSum == s * s)
                count++;
        }

        Console.WriteLine(count);
    }

    static int SumOfDigits(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }

    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }
}