// Running class derived from Activity
public class Running : Activity
{
    // Private field for distance (encapsulation)
    private double _distanceInKm;

    // Constructor
    public Running(DateTime date, int lengthInMinutes, double distanceInKm) 
        : base(date, lengthInMinutes)
    {
        _distanceInKm = distanceInKm;
    }

    // Override methods
    public override double GetDistance()
    {
        return _distanceInKm;
    }

    public override double GetSpeed()
    {
        // Speed = (distance / minutes) * 60
        return (_distanceInKm / LengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        // Pace = minutes / distance
        return LengthInMinutes / _distanceInKm;
    }
}
