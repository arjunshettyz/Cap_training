class LifeInsurance: InsurancePolicy
{
    public LifeInsurance(int policyNo, double premiumPlan, string holderName): base(policyNo, premiumPlan, holderName)
    {
        
    }
    public override double CalculatePremium()
    {
        return base.PremiumPlan * 3;
    }
    public new void Display()
    {
        Console.WriteLine("------------- Thanks for choosing Life Insurance Policy --------------");
        Console.WriteLine($"Policy Holder Name: {base.PolicyHolderName}");
        Console.WriteLine($"Policy Number: {base.PolicyNumber}");
        Console.WriteLine($"Policy Premium Property: {base.PremiumPlan}");
        Console.WriteLine("---------------------------");

    }
}