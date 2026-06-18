// Swimming class derived from Activity
public class Swimming : Activity
{
    // Private field for laps (encapsulation)
    private int _laps;

    // Constant for lap length (50 meters)
    private const double LapLengthInMeters = 50;

    // Constructor
    public Swimming(DateTime date, int lengthInMinutes, int laps) 
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    // Override methods
    public override double GetDistance()
    {
        // Distance (km) = laps * 50 / 1000
        return _laps * LapLengthInMeters / 1000.0;
    }

    public override double GetSpeed()
    {
        // Speed = (distance / minutes) * 60
        return (GetDistance() / LengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        // Pace = minutes / distance
        return LengthInMinutes / GetDistance();
    }
}
