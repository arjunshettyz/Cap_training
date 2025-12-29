class HealthInsurance: InsurancePolicy
{
    public HealthInsurance(int policyNo, double premiumPlan, string holderName) : base(policyNo, premiumPlan, holderName)
    {
        
    }
    public sealed override double CalculatePremium()
    {
        return base.PremiumPlan * 2;
    }
}