class Parent
{
    public string name;
    public Parent(string name)
    {
        this.name = name;

    }
}

class Child: Parent
{
    public int roll;
    public Child(int roll, string name): base(name)
    {
        this.roll = roll;
    }
}