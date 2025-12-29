// See https://aka.ms/new-console-template for more information


class Program
{
    public static void Main()
    {
        Console.WriteLine("***********Welcome to Insurence Management System**********");
        
        bool isAuthenticated = false;
        while (!isAuthenticated)
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (UserAuthentication.AuthenticateUser(email, password))
            {
                isAuthenticated = true;
                Console.WriteLine("User authenticated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid, Please Enter correct Email and Password: ");
            }
        }

        Console.Write("Enter Premium Number: ");
        int premiumNum;
        while (!int.TryParse(Console.ReadLine(), out premiumNum))
        {
            Console.Write("Please Enter Valid Premium Number: ");
        }

        Console.Write("Enter Your Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Premium Amount: ");
        double amount;
        while(!double.TryParse(Console.ReadLine(), out amount))
        {
            Console.Write("Please Enter Valid Amount: ");
        }


        InsurancePolicy lifeInsurance = new LifeInsurance(premiumNum, amount, name);
        InsurancePolicy healthInsurance = new HealthInsurance(102, 8000, "Aryan");

        PolicyDirectory store = new PolicyDirectory();
        store.AddData(lifeInsurance);
        store.AddData(healthInsurance);

        Console.WriteLine("----------Insurance Information--------");
        Console.WriteLine($"Holder Name: {store[0].PolicyHolderName}");
        Console.WriteLine($"Holder Premium Plan: {store["Aryan"].PremiumPlan}");

        Console.WriteLine("Life Premium: " + lifeInsurance.CalculatePremium());
        Console.WriteLine("Health Premium: " + healthInsurance.CalculatePremium());

        LifeInsurance life = new LifeInsurance(103, 6000, "Rahul");
        life.Display();
        InsurancePolicy baseRef = life;
        baseRef.Display();


    }
}
