public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
        
    }

    public override void RecordEvent(Goal goal)
    {

    }

    public override bool IsComplete()
    {
        throw new NotImplementedException();
    }

    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }
}