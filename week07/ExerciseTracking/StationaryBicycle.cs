public class StationaryBicycle : Activity
{
    private double _speed;

    // Added 'string unit' to the parameters
    public StationaryBicycle(string date, int minutes, double speed, string unit = "km") 
        : base(date, minutes, unit) // Passing unit to the base class
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * GetMinutes()) / 60;

    public override double GetSpeed() => _speed;

    public override double GetPace() => 60 / _speed;
}