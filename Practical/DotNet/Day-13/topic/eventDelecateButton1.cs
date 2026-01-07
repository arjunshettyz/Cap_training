using System;

class Button
{
    public delegate void ClickHandler();

    public  event ClickHandler? Clicked;
    public void Click()
    {
        Console.WriteLine("Button clicked");
        Clicked?.Invoke();
    }
}

class Program
{
    static void OnButtonClicked()
    {
        Console.WriteLine("Hander 1: click event");
    }
    static void PlaySound()
    {
        Console.WriteLine("Hander 2: click PlaySound");
    }
    static void StartEvent()
    {
        Console.WriteLine("Hander 3: click StartEvent");
    }

    static void Main()
    {
        Button btn = new Button();

        btn.Clicked += OnButtonClicked;
        btn.Clicked += PlaySound;
        btn.Clicked += StartEvent;

        btn.Click();
    }
}

