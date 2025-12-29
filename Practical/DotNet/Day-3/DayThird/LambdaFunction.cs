class LambdaFunction
{
    public static void Example()
    {
        int Square(int x)
        {
            return x * x;
        }
        Func<int, int> squareLambda = x => x * x;

        Console.WriteLine(Square(4));
        Console.WriteLine(squareLambda(4));

        int ans = squareLambda(5);
        Console.WriteLine(ans);
    }
}