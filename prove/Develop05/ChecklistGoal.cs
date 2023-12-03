
public class ChecklistGoal : Goal
{
    private int _amountCompleted = 0;
    private int _target;
    private int _bonus;
    private bool _isComplete;
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

    public void SetTarget(int target)
    {
        _target = target;
    }

    // Gets the _bonus.
    public int GetBonus()
    {
        return _bonus;
    }

    public void SetBonus(int bonus)
    {
        _bonus = bonus;
    }

    // Gets the _target.
    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }

    public override void RecordEvent()
    {
        _amountCompleted += 1;
    }

    public override bool IsComplete()
    {
        if (_target == _amountCompleted)
        {
            _isComplete = true;
            return _isComplete;
        }
        else
        {
            _isComplete = false;
            return _isComplete;
        }
    }
    public void SetIsComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }

    public override string GetStringRepresentation(string stringRepresentation)
    {
        return stringRepresentation;
    }
}