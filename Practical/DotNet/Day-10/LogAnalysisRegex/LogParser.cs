using System;
using System.Text.RegularExpressions;

namespace LogProcessing
{
    public class LogParser
    {
        private readonly string validLineRegexPattern = @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
        private readonly string splitLineRegexPattern = @"<\*{3}>|<={4}>|<\^\*>";
        private readonly string quotedPasswordRegexPattern = "\"password[^\"]*\"";
        private readonly string endOfLineRegexPattern = @"end-of-line\d+";
        private readonly string weakPasswordRegexPattern = @"password[a-zA-Z0-9]+";

        public bool IsValidLine(string text)
        {
            return !string.IsNullOrEmpty(text) &&
                   Regex.IsMatch(text, validLineRegexPattern);
        }

        public string[] SplitLogLine(string text)
        {
            return string.IsNullOrEmpty(text)
                ? Array.Empty<string>()
                : Regex.Split(text, splitLineRegexPattern);
        }

        public int CountQuotedPasswords(string lines)
        {
            return string.IsNullOrEmpty(lines)
                ? 0
                : Regex.Matches(lines, quotedPasswordRegexPattern,
                    RegexOptions.IgnoreCase).Count;
        }

        public string RemoveEndOfLineText(string line)
        {
            return string.IsNullOrEmpty(line)
                ? line
                : Regex.Replace(line, endOfLineRegexPattern, "");
        }

        public string[] ListLinesWithPasswords(string[] lines)
        {
            if (lines == null) return Array.Empty<string>();

            string[] result = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                Match m = Regex.Match(
                    lines[i],
                    weakPasswordRegexPattern,
                    RegexOptions.IgnoreCase);

                result[i] = m.Success
                    ? m.Value + ": " + lines[i]
                    : "--------: " + lines[i];
            }
            return result;
        }

        public void RunDemo()
        {
            Console.WriteLine(IsValidLine("[INF] Application started"));

            string log = "[INF] User login<***>Session created<====>Access granted";
            foreach (var part in SplitLogLine(log))
                Console.WriteLine(part);

            string text =
                "User said \"password123 is weak\"\n" +
                "Admin noted \"PASSWORD456 expired\"";

            Console.WriteLine(CountQuotedPasswords(text));

            Console.WriteLine(
                RemoveEndOfLineText("Transaction done end-of-line456"));

            string[] lines =
            {
                "User entered password123 during login",
                "System startup completed",
                "Admin reset passwordABC"
            };

            foreach (var line in ListLinesWithPasswords(lines))
                Console.WriteLine(line);
        }
    }
}
