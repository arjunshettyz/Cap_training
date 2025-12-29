// class Employee
// {
//     private double salary;
//     public double Salary
//     {
//         get { return salary; }
//         set
//         {
//             if (value > 0)
//                 salary = value;
//         }
//     }
// }


class EmployeeDirectory
{
    public  Dictionary<int, string> employees = new Dictionary<int, string>();

    public virtual string this[int id]
    {
        get { return employees[id]; }
        set { employees[id] = value; }
    }

    public string this[string name]
    {
        get
        {
            return employees.FirstOrDefault(e => e.Value == name).Value;
        }
    }
}

class Employee: EmployeeDirectory
{
    public override string this[int id]
    {
        get { return employees[id]; }
        set { employees[id] = value; }
    }
}