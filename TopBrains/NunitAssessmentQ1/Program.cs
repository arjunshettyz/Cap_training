using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] parts = input.Split(' ');

        double?[] values = new double?[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].ToLower() == "null")
                values[i] = null;
            else
                values[i] = double.Parse(parts[i]);
        }

        double? avg = GetAverage(values);

        if (avg == null)
            Console.WriteLine("null");
        else
            Console.WriteLine(avg.Value.ToString("F2"));
    }

    static double? GetAverage(double?[] values)
    {
        double sum = 0;
        int count = 0;

        foreach (double? v in values)
        {
            if (v.HasValue)
            {
                sum += v.Value;
                count++;
            }
        }

        if (count == 0)
            return null;

        return Math.Round(sum / count, 2, MidpointRounding.AwayFromZero);
    }
}