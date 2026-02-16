public class Running : Activity
{
    private double _distance;

    public Running(string date, int minutes, double distance, string unit = "km") 
        : base(date, minutes, unit)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / GetMinutes()) * 60;
    public override double GetPace() => GetMinutes() / _distance;
}