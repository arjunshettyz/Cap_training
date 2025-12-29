// Named Argument
class Person
{
    public void person(string name, int age, string city, char gender = 'M')
    {
        Console.WriteLine($"Name: {name}, Age: {age}, City: {city}, Gender: {gender}");
    }
}