// Cycling class derived from Activity
public class Cycling : Activity
{
    // Private field for speed (encapsulation)
    private double _speedInKph;

    // Constructor
    public Cycling(DateTime date, int lengthInMinutes, double speedInKph) 
        : base(date, lengthInMinutes)
    {
        _speedInKph = speedInKph;
    }

    // Override methods
    public override double GetDistance()
    {
        // Distance = speed * (minutes / 60)
        return _speedInKph * (LengthInMinutes / 60.0);
    }

    public override double GetSpeed()
    {
        return _speedInKph;
    }

    public override double GetPace()
    {
        // Pace = 60 / speed
        return 60 / _speedInKph;
    }
}
