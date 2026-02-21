using System;
using System.Collections.Generic;

public static class Extensions
{
    // Custom DistinctBy extension method
    public static IEnumerable<T> DistinctBy<T, TKey>(
        this IEnumerable<T> source,
        Func<T, TKey> keySelector)
    {
        HashSet<TKey> seen = new HashSet<TKey>();

        foreach (var item in source)
        {
            TKey key = keySelector(item);
            if (seen.Add(key)) // Add returns true if key not already present
            {
                yield return item;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        string[] items = Console.ReadLine().Split(' ');

        List<string> result = new List<string>();

        foreach (var item in items.DistinctBy(x => x.Split(':')[0]))
        {
            string name = item.Split(':')[1];
            result.Add(name);
        }

        Console.WriteLine(string.Join(" ", result));
    }
}