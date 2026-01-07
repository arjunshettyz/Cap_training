using System.Text.RegularExpressions;
using System;

public class RegexPattern
{
    public static void Match()
    {

        // Match m1 = Regex.Match("Hello123", @"\d+");
        // Console.WriteLine(m1.Value);

        //----------------------------------------------------------
    //    MatchCollection matches = Regex.Matches("10A20B30C", @"\d+");
    //     Match m = Regex.Match("10A20B30", @"\W");

    //     Console.WriteLine(m.Success ? m.Value : "No non-word char");

    //     foreach (Match with in matches)
    //     {
    //         Console.WriteLine(with.Value);
        // }

    //--------------------------------------------------------

        // string input = "2025-02-23, 2025-09-21";
        // string pattern = @"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";

        // Match m = Regex.Match(input, pattern);

        // Console.WriteLine(m.Groups["year"].Value);
        // Console.WriteLine(m.Groups["month"].Value);
        // Console.WriteLine(m.Groups["date"].Value);


        //------------------------------------------

        string input = "Date: 1992-02-23";
        string pattern = @"(\d{4})-(\d{2})-(\d{2})";

        Match m = Regex.Match(input, pattern);

        Console.WriteLine(m.Groups[0].Value); 
        Console.WriteLine(m.Groups[1].Value);
        Console.WriteLine(m.Groups[2].Value); 
        Console.WriteLine(m.Groups[3].Value); 




    }
}
