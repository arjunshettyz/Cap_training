using System;
 

delegate int MyDelegate(int a, int b);
class Program
{
    static int Add(int x, int y)
    {
        return x+y;
    }
    static int Sub(int x, int y)
    {
        return x-y;
    }
    public static void Main(String[] args){
        MyDelegate del = Add;
        Console.WriteLine("Add :"+del(10,5));

        del = Sub;
        Console.WriteLine("Sub :"+del(10,5));

    
	  
    }
}