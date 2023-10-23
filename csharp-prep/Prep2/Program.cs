using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercent = Console.ReadLine();
        int gradeNum = int.Parse(gradePercent);

        string letter = "";
        
        if (gradeNum >= 90)
        {
            letter = "A";
        }
        else if (gradeNum >= 80 && gradeNum < 90)
        {
            letter = "B";
        }
        else if (gradeNum >= 70 && gradeNum < 80)
        {
            letter = "C";
        }
        else if (gradeNum >= 60 && gradeNum < 70)
        {
            letter = "D";
        }
        else if (gradeNum < 60)
        {
            letter = "F";
        }
        
        if (letter == "A" || letter == "F")
        {
            Console.WriteLine($"You got an {letter}");
        }
        else 
        {
            Console.WriteLine($"You got a {letter}");
        }

        if (letter == "A" || letter == "B" || letter == "C")
        {
            Console.WriteLine("Congratulations you passed the course!");
        }
        else
        {
            Console.WriteLine("Sorry you didn't pass the course, study hard and i'm sure you'll get it next time!");
        }
    }

}