class ContractEmployee : EmployeeRecord
{
    public double HourlyRate {get; set;}

    public ContractEmployee(){}

    public override double GetMonthlyPay()
    {
        double totalWeeklyHours = 0.0;
        foreach (double hr in WeeklyHours)
        {
            totalWeeklyHours += hr;
        }

        return totalWeeklyHours * HourlyRate;
    }
}