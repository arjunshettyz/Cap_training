using System;
using System.Linq;

// Sorted arrays: merge two sorted arrays into one sorted array
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter first sorted array (space-separated integers):");
        int[] a = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Console.WriteLine("Enter second sorted array (space-separated integers):");
        int[] b = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int[] merged = MergeSorted(a, b);
        Console.WriteLine(string.Join(" ", merged));
    }

    static int[] MergeSorted(int[] a, int[] b)
    {
        int[] result = new int[a.Length + b.Length];
        int i = 0, j = 0, k = 0;
        while (i < a.Length && j < b.Length)
        {
            if (a[i] <= b[j])
                result[k++] = a[i++];
            else
                result[k++] = b[j++];
        }
        while (i < a.Length) result[k++] = a[i++];
        while (j < b.Length) result[k++] = b[j++];
        return result;
    }
}
