public class Swimming : Activity
{
    private int _laps; // each lap is 50 meters

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Convert meters to miles: 50m/lap * laps / 1000 m/km * 0.621371 km/mile
        return _laps * 50 / 1000 * 0.621371;
    }

    public override double GetSpeed()
    {
        int minutes = Getminutes();
        return (GetDistance() / minutes) * 60;
    }

    public override double GetPace()
    {
        int minutes = Getminutes();
        return minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Laps: {_laps}";
    }
}
