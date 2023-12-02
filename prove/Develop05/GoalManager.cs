public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager()
    {

    }

    public void Start()
    {
        string condition = " ";

        while (condition != "6")
        {
            Console.Clear();
            Console.WriteLine($"Your score is {_score}");
            Console.WriteLine("");
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");
            condition = Console.ReadLine();

            if (condition == "1")
            {
                CreateGoal();
            }
            else if(condition == "2")
            {
                ListGoalDetails();
                Console.Write("Press enter to return to the main menu: ");
                Console.ReadLine();
            }
            else if(condition == "3")
            {
                Console.Write("What is the filname of the goal file? ");
                string fileName = Console.ReadLine();
                SaveGoals(fileName);
            }
            else if(condition == "4")
            {
                Console.Write("What is the filname of the goal file? ");
                string fileName = Console.ReadLine();
                LoadGoals(fileName);
            }
            else if(condition == "5")
            {
                RecordEvent();
                Console.Write("Press enter to return to the main menu: ");
                Console.ReadLine();
            }
        }
    }

    public void DisplayPlayerInfo()
    {

    }

    public void ListGoalNames()
    {
        int number = 0;

        Console.WriteLine("The goals are: ");
        foreach (Goal g in _goals)
        {
            number = number + 1;
            Console.WriteLine($" {number}. {g.GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        int number = 0;

        Console.WriteLine("The goals are: ");
        foreach (Goal g in _goals)
        {
            number = number + 1;
            Console.WriteLine($" {number}. {g.GetDetailsString()}");
        }
    }
    
    public void CreateGoal()
    {
        string condition = " ";
        while (condition != "done")
        {
            Console.WriteLine("The Types of Goals are:");
            Console.WriteLine(" 1. Simple Goal");
            Console.WriteLine(" 2. Eternal Goal");
            Console.WriteLine(" 3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.Write("What is the name of your goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                string points = Console.ReadLine();

                SimpleGoal simpleGoal1 = new SimpleGoal(name, description, points);

                _goals.Add(simpleGoal1);
                condition = "done";

            }
            else if (userInput == "2")
            {
                Console.Write("What is the name of your goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                string points = Console.ReadLine();

                EternalGoal eternalGoal1 = new EternalGoal(name, description, points);
                
                _goals.Add(eternalGoal1);
                condition = "done";

            }
            else if (userInput == "3")
            {
                Console.Write("What is the name of your goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                string points = Console.ReadLine();
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                string targetString = Console.ReadLine();
                int target = int.Parse(targetString);
                Console.Write("What is the bonus for accomplishing it that many times? ");
                string bonusString = Console.ReadLine();
                int bonus = int.Parse(bonusString);

                ChecklistGoal checklistGoal1 = new ChecklistGoal(name, description, points, target, bonus);
                _goals.Add(checklistGoal1);
                condition = "done";

            }
        }
    }

    public void RecordEvent()
    {
            ListGoalNames();
            Console.Write("Which goal did you accomplish? ");
            string userInputString = Console.ReadLine();
            int userInput = int.Parse(userInputString);

            int points = _goals[userInput - 1].RecordEvent();
            _score = _score + points;
    }

    public void SaveGoals(string file)
    {
        string fileName = file;
        
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine($"{_score}");
            foreach (Goal g in _goals)
            {
                outputFile.WriteLine($"{g.GetStringRepresentation()}");
            }
        }
    }

    public void LoadGoals(string file)
    {
        string fileName = file;

        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            if (parts[0] == "SimpleGoal:")
            {
                SimpleGoal newSimpleGoal = new SimpleGoal(parts[1],parts[2],parts[3],bool.Parse(parts[4]));
                _goals.Add(newSimpleGoal);
            }
            else if (parts[0] == "EternalGoal:")
            {
                EternalGoal newEternalGoal = new EternalGoal(parts[1],parts[2],parts[3]);
                _goals.Add(newEternalGoal);
            }
            else if (parts[0] == "ChecklistGoal:")
            {
                ChecklistGoal newChecklistGoal = new ChecklistGoal(parts[1],parts[2],parts[3],int.Parse(parts[5]),int.Parse(parts[4]),int.Parse(parts[6]));
                _goals.Add(newChecklistGoal);
            }
            else
            {
                _score = int.Parse(parts[0]);
            }
        }
    }
}