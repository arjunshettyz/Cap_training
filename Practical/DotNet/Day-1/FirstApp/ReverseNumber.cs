class ReverseNumber
{
    public static void reverseNumber()
    {
        int num = 123;

        Console.WriteLine("Before: " + num);

        int newNum = 0;

        while(num > 0)
        {
            int rem = num % 10;
            newNum = newNum * 10 + rem;
            num = num / 10;
        }

        Console.WriteLine("After: " + newNum);

    }
}