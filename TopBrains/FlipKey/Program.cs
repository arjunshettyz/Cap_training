using System;
using System.Collections.Generic;
using System.Linq;

// FlipKey: flip key-value pairs in a dictionary (keys become values, values become keys)
class Program
{
    static void Main()
    {
        // Input: "a:1 b:2 c:1" -> flip to value->key(s). Output: "1:a,c 2:b" or similar
        Console.WriteLine("Enter key:value pairs separated by spaces (e.g. a:1 b:2 c:1):");
        string input = Console.ReadLine() ?? "";
        var pairs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, string> original = new Dictionary<string, string>();
        foreach (string pair in pairs)
        {
            string[] kv = pair.Split(':');
            if (kv.Length == 2)
                original[kv[0].Trim()] = kv[1].Trim();
        }

        // Flip: new key = old value, new value = list of old keys
        var flipped = new Dictionary<string, List<string>>();
        foreach (var kv in original)
        {
            if (!flipped.ContainsKey(kv.Value))
                flipped[kv.Value] = new List<string>();
            flipped[kv.Value].Add(kv.Key);
        }

        foreach (var kv in flipped.OrderBy(x => x.Key))
            Console.WriteLine($"{kv.Key}:{string.Join(",", kv.Value)}");
    }
}
