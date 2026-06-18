using System;
using System.Collections.Generic;

// Base Activity class
public abstract class Activity
{
    // Private fields (encapsulation)
    private DateTime _date;
    private int _lengthInMinutes;

    // Constructor
    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    // Public properties to access private fields
    public DateTime Date => _date;
    public int LengthInMinutes => _lengthInMinutes;

    // Abstract methods to be overridden in derived classes (polymorphism)
    public abstract double GetDistance();  // in km or miles
    public abstract double GetSpeed();     // in kph or mph
    public abstract double GetPace();      // in min per km or min per mile

    // Virtual method - can be overridden but not required
    public virtual string GetSummary()
    {
        // Using the abstract methods to generate the summary
        return $"{Date:dd MMM yyyy} {GetType().Name} ({LengthInMinutes} min) - Distance: {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F1} min per km";
    }
}
