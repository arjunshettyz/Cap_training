class Payroll
{
    public static List<EmployeeRecord> list = new List<EmployeeRecord>();
    public void RegisterEmployee(EmployeeRecord record)
    {
        list.Add(record);
        Console.WriteLine("Employee Registered Successfully!");
    }

    public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach(var emp in records)
        {
            int count = 0;
            foreach(double hour in emp.WeeklyHours)
            {
                if(hour >= hoursThreshold)
                {
                    count++;
                }
            }

            if(count > 0)
            {
                dict.Add(emp.EmployeeName, count);
            }
        }
        return dict;
    }

    public double CalculateAverageMonthlyPay()
    {
        int n = list.Count;
        if(n == 0) return 0.0;

        double sum = 0;

        foreach(var emp in list)
        {
            sum += emp.GetMonthlyPay();
        }

        double avg = sum / n;

        return avg; 

    }
}