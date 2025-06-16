public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _timesCompleted = 0;
    }

    public override void RecordProgress()
    {
        _timesCompleted++;
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetProgress()
    {
        return $"[∞] (Completed {_timesCompleted} times)";
    }
}