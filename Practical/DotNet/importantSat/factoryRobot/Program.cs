using System;

// Custom Exception Class
public class RobotSafetyException : Exception
{
    public RobotSafetyException(string message) : base(message)
    {
    }
}

// RobotHazardAuditor Class
public class RobotHazardAuditor
{
    // Method to Calculate Hazard Risk Score
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        // Validate Arm Precision
        if (armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error:  Arm precision must be 0.0-1.0");
        }

        // Validate Worker Density
        if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }

        // Validate Machinery State and Assign Risk Factor
        double machineRiskFactor;

        if (machineryState == "Worn")
        {
            machineRiskFactor = 1.3;
        }
        else if (machineryState == "Faulty")
        {
            machineRiskFactor = 2.0;
        }
        else if (machineryState == "Critical")
        {
            machineRiskFactor = 3.0;
        }
        else
        {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }

        // Hazard Risk Calculation Formula
        double hazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);

        return hazardRisk;
    }
}

// Program Class
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            RobotHazardAuditor auditor = new RobotHazardAuditor();

            // Input Arm Precision
            Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
            double armPrecision = Convert.ToDouble(Console.ReadLine());

            // Input Worker Density
            Console.WriteLine("Enter Worker Density (1 - 20):");
            int workerDensity = Convert.ToInt32(Console.ReadLine());

            // Input Machinery State
            Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
            string machineryState = Console.ReadLine();

            // Calculate Hazard Risk Score
            double risk = auditor.CalculateHazardRisk(armPrecision, workerDensity, machineryState);

            // Output Result
            Console.WriteLine("Robot Hazard Risk Score: " + risk);
        }
        catch (RobotSafetyException ex)
        {
            // Display Exception Message
            Console.WriteLine(ex.Message);
        }
    }
}
