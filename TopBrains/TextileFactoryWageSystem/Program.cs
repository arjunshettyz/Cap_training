using System;

// Textile factory wage: rate per piece produced (piece rate)
class Program
{
    static void Main()
    {
        const decimal ratePerPiece = 2.50m;
        const int minPiecesForBonus = 100;
        const decimal bonusPercent = 0.10m;

        Console.WriteLine("Enter number of pieces produced:");
        int pieces = int.Parse(Console.ReadLine() ?? "0");

        decimal wage = pieces * ratePerPiece;
        if (pieces >= minPiecesForBonus)
            wage += wage * bonusPercent;

        Console.WriteLine($"Wage: ${wage:F2}");
    }
}
