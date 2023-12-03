public class EternalGoal : Goal
{
    private bool _isComplete;

    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
        
    }

    // Didn't utilize this method from the base class.
    public override void RecordEvent()
    {
        throw new NotImplementedException();
    }

    // Use for determining if goal is complete.
    public override bool IsComplete()
    {
        return _isComplete;
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