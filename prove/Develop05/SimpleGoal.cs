public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent(Goal goal)
    {
        
    }

    public override bool IsComplete()
    {
        _isComplete = true;
        return _isComplete;
    }

    // Gets the _isComplete
    public bool GetIsComplete()
    {
        return _isComplete;
    }

    public void SetIsComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }

    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }
}