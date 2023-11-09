using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator prompt1 = new PromptGenerator();
        prompt1._prompts.Add("Who was the most interesting person I interacted with today?");
        prompt1._prompts.Add("What was the best part of my day?");
        prompt1._prompts.Add("How did I see the hand of the Lord in my life today?");
        prompt1._prompts.Add("What was the strongest emotion I felt today?");
        prompt1._prompts.Add("If I had one thing I could do over today, what would it be?");
        prompt1._prompts.Add("What were your highs and lows today?");

        Journal journal1 = new Journal();

        int userInput = 1;
        while (userInput != 6)
        {
            
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Create Prompt");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");
            
            string userResponse = Console.ReadLine();
            userInput = int.Parse(userResponse);

            if (userInput == 1)
            {
                string prompt = prompt1.GetRandomPrompt();
                Console.WriteLine($"{prompt}");
                string entry = Console.ReadLine();
                
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();

                Entry entry1 = new Entry();
                entry1._date = $"{dateText}";
                entry1._entryText = $"{entry}";
                entry1._promptText = $"{prompt}";

                journal1._entries.Add(entry1);
                
            }
            else if (userInput == 2)
            {
                journal1.DisplayAll();
            }
            else if (userInput == 3)
            {
                Console.WriteLine("What is your filename?");
                string file1 = Console.ReadLine();

                journal1.LoadFromFile(file1);
            }
            else if (userInput == 4)
            {
                Console.WriteLine("What is your filename?");
                string file = Console.ReadLine();

                journal1.SaveToFile(file, journal1._entries);
            }
            else if (userInput == 5)
            {
                Console.WriteLine("What would you like your prompt to say?");
                string newPrompt = Console.ReadLine();

                prompt1._prompts.Add($"{newPrompt}");
                
                string entry = Console.ReadLine();
                
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();

                Entry entry1 = new Entry();
                entry1._date = $"{dateText}";
                entry1._entryText = $"{entry}";
                entry1._promptText = $"{newPrompt}";

                journal1._entries.Add(entry1);
            }

        }
    }
}