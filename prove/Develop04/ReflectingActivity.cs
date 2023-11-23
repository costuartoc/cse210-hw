public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectingActivity(List<string> prompts, List<string> questions)
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _duration = 10;
        foreach (string prompt in prompts)
        {
            _prompts.Add(prompt);
        }
        foreach (string question in questions)
        {
            _questions.Add(question);
        }
    }
    public void Run()
    {
        Console.Clear();
        
        DisplayStartingMessage();
        
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();
        
        DisplayPrompt();
        DisplayQuestions();
        
        DisplayEndingMessage();
    }
    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        string prompt = _prompts[index];
        return prompt;
    }
    public string GetRandomQuestion()
    {
        Random rnd = new Random();
        int index = rnd.Next(_questions.Count);
        string question = _questions[index];
        return question;
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

    }
    public void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < futureTime)
        {
            string question = GetRandomQuestion();
            Console.WriteLine($"{question}");
            ShowSpinner(5);
        }
    }
}
