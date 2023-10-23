using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers type 0 when finished.");

        int condition = -1;

        while (condition == -1)
        {
            Console.Write("Enter Number (0 to quit): ");
            string inNumber = Console.ReadLine();
            int number = int.Parse(inNumber);

            if (number != 0)
            {
                numbers.Add(number);
            }
            else{
                condition = 0;
            }
        }
        
        int sum = 0;
        int largest = 0;

        foreach ( int number in numbers)
        {
            sum = sum + number;
            
            if (number > largest)
            {
                largest = number;
            }
        }
    
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"Thelargest number is: {largest}");
    }
}