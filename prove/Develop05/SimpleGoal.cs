public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _isComplete = false;
    }
    public SimpleGoal(string name, string description, string points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete == true)
        {
            Console.WriteLine("You've already completed this goal.");
            return 0;
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {_points} points!");
            _isComplete = true;
            return int.Parse(_points);
        }
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:,{_shortName},{_description},{_points},{_isComplete}";
    }
}