using System;
 
// interface IGear{
// 	void display();
// }

// class MainCar : IGear{
    
// 	public void display(){
// 		Console.WriteLine("interface");
// 	}
// }


public abstract class Vehicle
{
    public string Brand { get; set; }

    public Vehicle(string brand)
    {
        Brand = brand;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Brand: {Brand}");
    }

    public abstract void Drive();
}

public class Car : Vehicle
{
    public Car(string brand) : base(brand)
    {
    }

    public override void Drive()
    {
        Console.WriteLine($"The {Brand} car is driving.");
    }
}


class Program
{
    public static void Main(String[] args){
	// MainCar t = new MainCar();
	// t.display();
    
	    Car myCar = new Car("Toyota");
        myCar.DisplayInfo();
        myCar.Drive();

        Vehicle anotherCar = new Car("Ford");
        anotherCar.DisplayInfo();
        anotherCar.Drive();
    }
}