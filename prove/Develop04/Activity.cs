public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = " ";
        _description = " ";
        _duration = 10;
    }
    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }
    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine($"{_description}");
        Console.WriteLine();
        Console.WriteLine("How long, in seconds, would you like for your session?");
        string userInput = Console.ReadLine();
        _duration = int.Parse(userInput);

        Console.Clear();
    }
    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }
    // instead of a spinner I've done a winking face animation
    protected void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add(":(");
        animationStrings.Add(":|");
        animationStrings.Add(":)");
        animationStrings.Add(";)");
        animationStrings.Add(":|");
        animationStrings.Add(":(");
        animationStrings.Add(":|");
        animationStrings.Add(":)");
        animationStrings.Add(";)");
        animationStrings.Add(":|");

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        
        int i = 0;
        
        while (DateTime.Now < futureTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b\b  \b\b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }

    }
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}