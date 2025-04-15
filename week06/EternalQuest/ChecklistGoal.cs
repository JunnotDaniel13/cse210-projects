public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0; 
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int bonus, int target, int amountCompleted)
        : base(name, description, points)
    {
        _bonus = bonus;
        _target = target;
        _amountCompleted = amountCompleted;
    }


    public override int RecordEvent()
    {
        if (!IsComplete()) 
        {
            _amountCompleted++;
            int pointsEarned = _points; 

            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");

            if (_amountCompleted == _target)
            {
                pointsEarned += _bonus; 
                Console.WriteLine($"Bonus! You completed the goal and earned an extra {_bonus} points!");
            }
            return pointsEarned;
        }
        else
        {
             Console.WriteLine($"Goal '{_shortName}' is already fully complete.");
            return 0; 
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }
}
