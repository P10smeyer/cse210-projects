public class ChecklistGoal : Goal
{
    private int _amountCompleted = 0;
    private int _target;
    private int _bonus;
    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    // Gets the _target.
    public int GetTarget()
    {
        return _target;
    }

    // Gets the _bonus.
    public int GetBonus()
    {
        return _bonus;
    }

    // Gets the _target.
    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public override void RecordEvent(Goal goal)
    {
        _amountCompleted += 1;
    }

    public override bool IsComplete()
    {
        if (_target == _amountCompleted)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }
}