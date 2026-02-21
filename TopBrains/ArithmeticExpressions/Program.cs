using System;

class Program
{
    static void Main()
    {
        string expression = Console.ReadLine();
        Console.WriteLine(EvaluateExpression(expression));
    }

    static string EvaluateExpression(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            return "Error:InvalidExpression";

        string[] parts = expression.Split(' ');

        // Check format: must be exactly 3 parts
        if (parts.Length != 3)
            return "Error:InvalidExpression";

        string aStr = parts[0];
        string op = parts[1];
        string bStr = parts[2];

        // Check valid integers
        if (!int.TryParse(aStr, out int a) || !int.TryParse(bStr, out int b))
            return "Error:InvalidNumber";

        switch (op)
        {
            case "+":
                return (a + b).ToString();

            case "-":
                return (a - b).ToString();

            case "*":
                return (a * b).ToString();

            case "/":
                if (b == 0)
                    return "Error:DivideByZero";
                return (a / b).ToString();

            default:
                return "Error:UnknownOperator";
        }
    }
}