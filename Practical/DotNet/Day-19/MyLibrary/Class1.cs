using System.Numerics;


public interface I1
{
    public  void m1();
    public  void m2();
}
public class A : I1
{
    public  void m1()
    {
        Console.WriteLine("This is method 1");

    }
    public void m2()
    {
        Console.WriteLine("This is m2");
    }

}

public class B : A
{
    public void m3()
    {
        Console.WriteLine("This is method m3 from class B");
    }
}
