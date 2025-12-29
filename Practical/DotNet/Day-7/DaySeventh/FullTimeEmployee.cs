class FullTimeEmployee : EmployeeRecord
{
    public double HourlyRate{get; set;}
    public double MonthlyBonus{get; set;}

    public FullTimeEmployee(){}

    public override double GetMonthlyPay()
    {
        double totalWeeklyHours = 0.0;
        foreach(double hr in WeeklyHours)
        {
            totalWeeklyHours += hr;
        }

        return (totalWeeklyHours * HourlyRate) + MonthlyBonus;
    }
}