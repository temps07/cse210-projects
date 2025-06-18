public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetDistance()
    {
        int minutes = Getminutes();
        return (_speed * minutes) / 60;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}
