abstract class InsurancePolicy
{
    protected int PolicyNumber {get; init;}
    private double premiumPlan;
    public string policyHolderName;

    public double PremiumPlan
    {
        get {return premiumPlan; }
        set
        {
            if(value > 0)
            {
                premiumPlan = value;
            }
        }
    }

    public string PolicyHolderName
    {
        get {return policyHolderName;}
        set { policyHolderName = value;}
    }

    public InsurancePolicy(int policyNumber, double premium, string holderName)
    {
        PolicyNumber = policyNumber;
        PremiumPlan = premium;
        PolicyHolderName = holderName;

    }

    public virtual double CalculatePremium()
    {
        return PremiumPlan;
    }
    
    public void Display()
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine($"Policy Holder Name: {PolicyHolderName}");
        Console.WriteLine($"Policy Number: {PolicyNumber}");
        Console.WriteLine($"Policy Premium Property: {PremiumPlan}");
        Console.WriteLine("---------------------------");

    }
    


}