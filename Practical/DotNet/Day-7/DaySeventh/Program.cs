// See https://aka.ms/new-console-template for more information
using System.Text;
class Program
{
    public static string CleanseAndInvert(string str)
    {
        if(str == null || str.Length < 6)
        {
            return "";
        }
        str = str.ToLower();

        StringBuilder sb = new StringBuilder();

        foreach(char ch in str)
        {
            if(ch >= 'a' && ch <= 'z')
            {
                if(ch % 2 != 0)
                {
                    sb.Append(ch);
                }
            }
            else
            {
                return "Invalid Input";
            }
        }

        StringBuilder sr = new StringBuilder();

        for(int i=sb.Length-1; i>=0; i--)
        {
            sr.Append(sb[i]);
        }
        sr.ToString();

        for(int i=0; i<sr.Length; i++)
        {
            if(i % 2 == 0)
            {
                sr[i] = Char.ToUpper(sr[i]);
            }
        }
        return sr.ToString();
    }
    public static void Main()
    {
        Console.WriteLine("Welcome to Day 7!");

        // Arrays.ArrayExample();

        // Console.WriteLine("Q.1 Find the frequency of elements in an array using a Dictionary");
        // Practice.DictPractice();

        // Console.WriteLine("Q.2 Merge Two Sorted Arrays: ");
        // MergeArray.Merge();

        // Console.WriteLine("Assignment 1: String Modification....");
        // Console.Write("Enter: ");
        // string? str = Console.ReadLine();
        // string res = CleanseAndInvert(str);
        // Console.WriteLine("Modified String: " + res);

        Console.WriteLine("Assignment 2: PayRollPro - OOPS + Collections Based");
        int choice = 0;

        while(choice != 4)
        {
            Console.WriteLine("1. Register Employee. \n2. Show Overtime Summary. \n3. Calculate Average Monthly Pay. \n4. Exit.");
            Console.Write("Enter your choice: ");

            while(!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid Input!");
            }

            switch (choice)
            {
                case 1:
                    {
                        Console.Write("Select Employee Type (1-Full Time, 2-Contract): ");
                        int empType = Convert.ToInt32(Console.ReadLine());

                        if(empType == 1)
                        {
                            Console.Write("Enter Employee Name: ");
                            string empName = Console.ReadLine();

                            Console.Write("Enter Hourly Rate: ");
                            double hourlyRate = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Enter Monthly Bonus: ");
                            double monthlyBonus = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("Enter weekly hours (Week 1 to 4): ");
                            double[] weeklyHours = new double[4];
                            for(int i=0; i<4; i++)
                            {
                                weeklyHours[i] = Convert.ToDouble(Console.ReadLine());
                            }
                            EmployeeRecord emp1 = new FullTimeEmployee
                            {
                                EmployeeName = empName,
                                HourlyRate = hourlyRate,
                                MonthlyBonus = monthlyBonus,
                                WeeklyHours = weeklyHours
                            };

                            Payroll payroll = new Payroll();
                            payroll.RegisterEmployee(emp1);

                        }else if(empType == 2)
                        {
                            Console.Write("Enter Employee Name: ");
                            string empName = Console.ReadLine();

                            Console.Write("Enter Hourly Rate: ");
                            double hourlyRate = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("Enter weekly hours (Week 1 to 4): ");
                            double[] weeklyHours = new double[4];
                            for (int i = 0; i < 4; i++)
                            {
                                weeklyHours[i] = Convert.ToDouble(Console.ReadLine());
                            }
                            EmployeeRecord emp1 = new ContractEmployee
                            {
                                EmployeeName = empName,
                                HourlyRate = hourlyRate,
                                WeeklyHours = weeklyHours
                            };

                            Payroll payroll = new Payroll();
                            payroll.RegisterEmployee(emp1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input!");
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter hours threshold: ");
                        double hoursThreshold = Convert.ToDouble(Console.ReadLine());

                        Payroll payroll = new Payroll();
                        Dictionary<string, int> dict = payroll.GetOvertimeWeekCounts(Payroll.list, hoursThreshold);

                        int n = dict.Count;
                        if(n > 0)
                        {
                            foreach (var emp in dict)
                            {
                                Console.WriteLine(emp.Key + " - " + emp.Value);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No overtime recorded this month.");
                        }
                        break;
                    }
                case 3:
                    {
                        Payroll payroll = new Payroll();
                        double avg = payroll.CalculateAverageMonthlyPay();
                        Console.WriteLine("Overall average monthly pay: " + avg);
                        break;
                    }   
                case 4:
                    {
                        Console.WriteLine("Logging off — Payroll processed successfully!");
                        break;
                    }              
            }

        }



    }
}
