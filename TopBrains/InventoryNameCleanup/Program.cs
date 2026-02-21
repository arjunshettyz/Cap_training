using System;
using System.Text;
using System.Globalization;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(CleanupName(input));
    }

    static string CleanupName(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "";

        // Step 1: Trim and remove extra spaces
        string[] words = input.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Step 2: Remove consecutive duplicate characters in each word
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = RemoveConsecutiveDuplicates(words[i].ToLower());
        }

        // Step 3: Convert to TitleCase
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = textInfo.ToTitleCase(words[i]);
        }

        return string.Join(" ", words);
    }

    static string RemoveConsecutiveDuplicates(string word)
    {
        StringBuilder result = new StringBuilder();
        result.Append(word[0]);

        for (int i = 1; i < word.Length; i++)
        {
            if (word[i] != word[i - 1])
            {
                result.Append(word[i]);
            }
        }

        return result.ToString();
    }
}