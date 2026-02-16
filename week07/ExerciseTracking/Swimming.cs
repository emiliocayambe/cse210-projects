public class Swimming : Activity
{
    private int _laps;

    // Added 'string unit' to the parameters
    public Swimming(string date, int minutes, int laps, string unit = "km") 
        : base(date, minutes, unit) // Passing unit to the base class
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Metric: 50 meters per lap / 1000 = km
        // Imperial: 50 meters per lap / 1000 * 0.62 = miles
        if (_unit == "miles")
            return _laps * 50 / 1000.0 * 0.62;
        
        return _laps * 50 / 1000.0;
    }

    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;

    public override double GetPace() => GetMinutes() / GetDistance();
}