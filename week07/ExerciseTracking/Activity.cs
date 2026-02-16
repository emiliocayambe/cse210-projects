using System;
using System.Globalization;

public abstract class Activity
{
    private string _date;
    private int _minutes;
    protected string _unit; // "km" or "miles"

    public Activity(string date, int minutes, string unit = "km")
    {
        _date = date;
        _minutes = minutes;
        _unit = unit;
    }

    public int GetMinutes() => _minutes;
    
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string distUnit = _unit == "km" ? "km" : "miles";
        string speedUnit = _unit == "km" ? "kph" : "mph";
        string paceUnit = _unit == "km" ? "min per km" : "min per mile";

        return $"{_date} {this.GetType().Name} ({_minutes} min): " +
               $"Distance {GetDistance().ToString("0.0", CultureInfo.InvariantCulture)} {distUnit}, " +
               $"Speed {GetSpeed().ToString("0.0", CultureInfo.InvariantCulture)} {speedUnit}, " +
               $"Pace: {GetPace().ToString("0.0", CultureInfo.InvariantCulture)} {paceUnit}";
    }
}