using System;
using System.Collections.Generic;

// Base Activity class
public class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Base class doesn't know how to calculate distance
    }

    public virtual double GetSpeed()
    {
        return 0; // Base class doesn't know how to calculate speed
    }

    public virtual double GetPace()
    {
        return 0; // Base class doesn't know how to calculate pace
    }

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

// Running class
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
        return (_distance / _minutes) * 60;
    }

    public override double GetPace()
    {
        return _minutes / _distance;
    }
}

// Cycling class
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
        return (_speed * _minutes) / 60;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

// Swimming class
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
        return (GetDistance() / _minutes) * 60;
    }

    public override double GetPace()
    {
        return _minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Laps: {_laps}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create activities
        Activity running = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        Activity cycling = new Cycling(new DateTime(2022, 11, 3), 30, 9.7);
        Activity swimming = new Swimming(new DateTime(2022, 11, 3), 30, 20);

        // Put activities in a list
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}