class SwapTwoNumber
{
    public static void swapTwoNumber()
    {
        int num1 = 20;
        int num2 = 23;

        Console.WriteLine($"Before: a = {num1}, b = {num2}");

        int temp = num1;
        num1 = num2;
        num2 = temp;
        Console.WriteLine($"After: a = {num1}, b = {num2}");
    }
}