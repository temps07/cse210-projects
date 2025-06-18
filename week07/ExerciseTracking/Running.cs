public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        int minutes = Getminutes();
        return (_distance / minutes) * 60;
    }

    public override double GetPace()
    {
        int minutes = Getminutes();
        return minutes / _distance;
    }
}