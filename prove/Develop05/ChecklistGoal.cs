
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

    // Sets the target
    public void SetTarget(int target)
    {
        _target = target;
    }

    // Gets the amount completed.
    public int GetTarget()
    {
        return _target;
    }

    // Sets the bonus
    public void SetBonus(int bonus)
    {
        _bonus = bonus;
    }

    // Gets the amount completed.
    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    // Sets how many times a checklist goal has been completed.
    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }

    // Action if event is recorded.
    public override void RecordEvent()
    {
        _amountCompleted += 1;
    }

    // Use for determining if goal is complete.
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

    // Sets goal completion status.
    public void SetIsComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }

    // The string representation of a goal (exported to a text file).
    public override string GetStringRepresentation(string stringRepresentation)
    {
        return stringRepresentation;
    }
}