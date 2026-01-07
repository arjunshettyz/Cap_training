using System;

class Button
{
    // Step 1: Declare a delegate
    public delegate void ClickHandler();

    // Step 2: Declare an event using the delegate
    public event ClickHandler Clicked;

    // Step 3: Method that raises the event
    public void Click()
    {
        Console.WriteLine("Button clicked");
        Clicked?.Invoke();
    }
}

class Program
{
    // Event handler method
    static void OnButtonClicked()
    {
        Console.WriteLine("Handling button click event");
    }

    static void Main()
    {
        Button btn = new Button();

        // Subscribe to the event
        btn.Clicked += OnButtonClicked;

        // Simulate button click
        btn.Click();
    }
}
