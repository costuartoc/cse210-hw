public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will hlp you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _duration = 10;
    }
    public void Run()
    {
        Console.Clear();

        DisplayStartingMessage();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();
        
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < futureTime)
        {   
            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine();
            Console.Write("Breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
        }

        DisplayEndingMessage();
        ShowSpinner(5);
    }
}