using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        string word1 = Console.ReadLine();
        string word2 = Console.ReadLine();

        // Store all consonants from word2 (case-insensitive)
        HashSet<char> consonantsInWord2 = new HashSet<char>();
        foreach (char c in word2.ToLower())
        {
            if (char.IsLetter(c) && !IsVowel(c))
            {
                consonantsInWord2.Add(c);
            }
        }

        // Task 1: Remove common consonants from word1
        StringBuilder filtered = new StringBuilder();
        foreach (char c in word1)
        {
            char lower = char.ToLower(c);
            if (IsVowel(lower) || !consonantsInWord2.Contains(lower))
            {
                filtered.Append(c);
            }
        }

        // Task 2: Remove consecutive duplicate characters
        StringBuilder result = new StringBuilder();
        foreach (char c in filtered.ToString())
        {
            if (result.Length == 0 || result[result.Length - 1] != c)
            {
                result.Append(c);
            }
        }

        Console.WriteLine(result.ToString());
    }

    static bool IsVowel(char c)
    {
        return "aeiou".Contains(c);
    }
}