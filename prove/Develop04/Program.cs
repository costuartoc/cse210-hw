using System;
// instead of a spinner I've done a winking face animation
class Program
{
    static void Main(string[] args)
    {

        List<string> reflectingPrompts = new List<string>();
        reflectingPrompts.Add("Think of a time when you stood up for someone else.");
        reflectingPrompts.Add("Think of a time when you did something really difficult.");
        reflectingPrompts.Add("Think of a time when you helped someone in need.");
        reflectingPrompts.Add("Think of a time when you did something truly selfless.");

        List<string> questions = new List<string>();
        questions.Add("Why was this experience meaningful to you?");
        questions.Add("Have you ever done anything like this before?");
        questions.Add("How did you get started?");
        questions.Add("How did you feel when it was complete?");
        questions.Add("What made this time different than other times when you were not as successful?");
        questions.Add("What is your favorite thing about this experience?");
        questions.Add("What could you learn from this experience that applies to other situations?");
        questions.Add("What did you learn about yourself through this experience?");
        questions.Add("How can you keep this experience in mind in the future?");

        List<string> listingPrompts = new List<string>();
        listingPrompts.Add("Who are people that you appreciate?");
        listingPrompts.Add("What are personal strengths of yours?");
        listingPrompts.Add("Who are people that you have helped this week?");
        listingPrompts.Add("When have you felt the Holy Ghost this month?");
        listingPrompts.Add("Who are some of your personal heroes?");

        BreathingActivity breathingActivity1 = new BreathingActivity();
        ReflectingActivity reflectingActivity1 = new ReflectingActivity(reflectingPrompts, questions);
        ListingActivity listingActivity1 = new ListingActivity(listingPrompts);
        
        int intUserInput = 0;
        
        while (intUserInput != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            string userInput = Console.ReadLine();
            intUserInput = int.Parse(userInput);

            if ( intUserInput == 1)
            {
                breathingActivity1.Run();
            }
            else if ( intUserInput == 2)
            {
                reflectingActivity1.Run();
            }
            else if ( intUserInput == 3)
            {
                listingActivity1.Run();
            }
            
        }
    }
}