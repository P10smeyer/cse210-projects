public abstract class Goal
{
    private string _shortName;
    private string _description;
    private string _points;

    public Goal(string shortName, string description, string points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent(Goal goal);
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    // Gets the _shortName
    public string GetName()
    {
        return _shortName;
    }

    public void SetName(string shortName)
    {
        _shortName = shortName;
    }

    // Gets the _description
    public string GetDescription()
    {
        return _description;
    }

    // Gets the _points
    public string GetPoints()
    {
        return _points;
    }
}