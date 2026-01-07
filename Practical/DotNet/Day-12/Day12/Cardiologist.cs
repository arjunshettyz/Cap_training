using System;

class Cardiologist : Doctor
{
    public Cardiologist(string name)
        : base(name, "Cardiology") // call parent constructor
    {
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Total Doctors: " + Doctor.TotalDoctors);
        Console.WriteLine("Doctor Name: " + Name);
        Console.WriteLine("Department: " + Department);
    }
}
