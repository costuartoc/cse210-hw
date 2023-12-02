public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }
    public ChecklistGoal(string name, string description, string points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        _amountCompleted = _amountCompleted + 1;
        if (_amountCompleted == _target)
        {
            Console.WriteLine($"Congratulations! You have earned {int.Parse(_points) + _bonus} points!");
            return int.Parse(_points) + _bonus;
        }
        if (_amountCompleted > _target)
        {
            _amountCompleted = _amountCompleted - 1;
            
            Console.WriteLine("You've already completed this goal.");
            return 0;
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {_points} points!");
            return int.Parse(_points);
        }
    }

    public override bool IsComplete()
    {
        if (_amountCompleted == _target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetDetailsString()
    {
        if (IsComplete() == true)
        {
            return $"[X] {_shortName} ({_description} -- Completed: {_amountCompleted}/{_target})";
        }
        else
        {
            return $"[ ] {_shortName} ({_description} -- Completed: {_amountCompleted}/{_target})";    
        }
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:,{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }
}