using System;

class Doctor
{
    // static member
    public static int TotalDoctors = 50;

    // non-static members
    public string Name;
    public string Department;

    // parent constructor
    public Doctor(string name, string department)
    {
        Name = name;
        Department = department;
    }
}
