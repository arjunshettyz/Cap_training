class LargestOfThreeNumber
{
    public static void largestOfThreeNumber()
    {
        Console.Write("Enter num1: ");
        int num1 = Convert.ToInt16(Console.ReadLine());
        Console.Write("Enter num2: ");
        int num2 = Convert.ToInt16(Console.ReadLine());
        Console.Write("Enter num3: ");
        int num3 = Convert.ToInt16(Console.ReadLine());

        if(num1 > num2 && num1 > num3)
        {
            Console.WriteLine("Largest Number: "+ num1);
        }else if(num2 > num3)
        {
            Console.WriteLine("Largest Number: "+ num2);

        }
        else
        {
            Console.WriteLine("Largest Number: "+ num3);
            
        }
    }
}