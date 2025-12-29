class Game
{
    public static void startGame()
    {
        Console.WriteLine("Game Begins!");
        for(int i=1; i<=10; i++)
        {
            if(i == 4)
            {
                Console.WriteLine("E4 is Invisible. Skipping E4");
                continue;

            }
            
            Console.WriteLine("Player Kiled E"+i);           
            
        }

        Console.WriteLine("Game End!");
    }
}