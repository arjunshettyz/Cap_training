class DriveOrNot
{
    public static void isDrive()
    {
        int age = 22;
        bool hasLicense = true;

        if(age >= 18)
        {
            if (hasLicense)
            {
                Console.WriteLine("You are allowed to drive.");
            }
            else
            {
                Console.WriteLine("License required.");
            }
        }
        else
        {
            Console.WriteLine("You are not allowed to drive.");
        }
    }
}
