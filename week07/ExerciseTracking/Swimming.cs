public class Swimming : Activity
{
    private int _laps; 
    private const double MetersPerLap = 50.0;
    private const double MetersToMiles = 0.000621371; 

    public Swimming(DateTime date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * MetersPerLap * MetersToMiles;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        if (_lengthMinutes == 0) return 0; 
        return (distance / _lengthMinutes) * 60.0;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance == 0) return 0; 
        return _lengthMinutes / distance;
    }
}
