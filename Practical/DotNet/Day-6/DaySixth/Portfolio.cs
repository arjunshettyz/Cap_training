using System;
class Portfolio
{
    public string Name;

    public override bool Equals(Object obj)
    {
        Portfolio p = obj as Portfolio;
        return p != null && p.Name == Name;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}