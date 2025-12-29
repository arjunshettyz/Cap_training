class Student
{
    private string name;
    private int age;
    private double marks;

    private string password; 


    public int StudentId {get; set;}               // Auto-Implemented Property (Just Like @Getter and @Setter in java/SpringBoot)

    // Normal Property that use get and set
    public String Name
    {
        get{return name;}
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
        }
    }
    public int Age
    {
        get {return age;}
        set
        {
            if(value > 0)
            {
                age = value;
            }
        }
    }

    public double Marks
    {
        get {return marks; }
        set
        {

            if (value >= 0 && value <= 100)
            {
                marks = value;
            }
        }
    }

    // Read-Only Property
    public string GetResult
    {
        get
        {
            if(marks >= 40)
            {
                return "Pass";
            }
            else
            {
                return "Fail";
            }
        }
    }

    //  Write-Only Property
    public string Password
    {
        set
        {
            if(value.Length >= 6)
            {
                password = value;
            }
        }
    }

    public int RegistrationNumber {get; private set;}

    public void setRegistrationNumber(int registrationNumber)
    {
        RegistrationNumber = registrationNumber;
    }

    public int AdmissionYear {get; init;}
    public double Percentage => (marks / 100.0) * 100;



}