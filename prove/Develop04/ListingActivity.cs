public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();

    public ListingActivity(List<string> prompts)
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _duration = 10;
        _count = 0;
        foreach (string prompt in prompts)
        {
            _prompts.Add(prompt);
        }
    }
    public void Run()
    {
        Console.Clear();
        
        DisplayStartingMessage();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();

        List<string> userList = new List<string>();
        userList = GetListFromUser();
        _count = userList.Count();

        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }
    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        string prompt = _prompts[index];
        return prompt;
    }
    public List<string> GetListFromUser()
    {
        List<string> userList = new List<string>();
        
        Console.WriteLine("List as many responses as you can to the following prompt:");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < futureTime)
        {
            string userInput = Console.ReadLine();
            userList.Add(userInput);
        }
        return userList;
    }
}