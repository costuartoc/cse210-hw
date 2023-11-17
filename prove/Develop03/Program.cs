using System;

class Program
{
    static void Main(string[] args)
    {
        string scripture = "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him and he shall direct thy paths.";

        string book = "Proverbs";
        int chapter = 3;
        int verse = 5;
        int endVerse = 6;

        Reference reference1 = new Reference(book, chapter, verse, endVerse);

        Scripture scripture1 = new Scripture(reference1, scripture);
        
        
        string condition = "";
        while(condition != "quit")
        {
            Console.Clear();
            string memorize = scripture1.GetDisplayText();

            Console.WriteLine(memorize);
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            condition = Console.ReadLine();
            bool isCompletelyHidden = scripture1.IsCompletelyHidden();
            if (isCompletelyHidden == true)
            {
                condition = "quit";
            }
            else if (condition != "quit" )
            {
                scripture1.HideRandomWords(3);
            }
        
        }
    }
}