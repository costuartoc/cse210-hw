using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Can you guess the magic number? ");
        
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);
        
        string condition = "no";

        while (condition == "no")
        {
            Console.Write("What is your guess? ");
            string inGuess = Console.ReadLine();
            int guess = int.Parse(inGuess);
            
            if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                condition = "yes";
            }
        }
    }
}