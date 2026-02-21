using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int upto = int.Parse(Console.ReadLine());

        int[] row = GetMultiplicationTable(n, upto);

        Console.WriteLine(string.Join(" ", row));
    }

    static int[] GetMultiplicationTable(int n, int upto)
    {
        int[] result = new int[upto];

        for (int i = 1; i <= upto; i++)
        {
            result[i - 1] = n * i;
        }

        return result;
    }
}