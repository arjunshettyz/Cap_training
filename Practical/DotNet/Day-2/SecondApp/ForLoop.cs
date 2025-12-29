class ForLoop
{
    public static void forLoop()
    {
        Console.WriteLine("Multiple of 5: ");
        for(int i=1; i<=10; i++)
        {
            Console.WriteLine($"5 * {i} = {5*i}");
        }

        for(int i=20; i<=30; i++)
        {
            Console.WriteLine("Multiple of "+ i);

            for(int j=1; j<=10; j++)
            {
                Console.WriteLine($"{i} * {j} = {i*j}");
            }
        }
    }
}