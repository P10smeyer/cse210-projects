public class EternalGoal : Goal
{
    private bool _isComplete;

    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
        
    }

    public override void RecordEvent()
    {

    }

     public override bool IsComplete()
    {
        return _isComplete;
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