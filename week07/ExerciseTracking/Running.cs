public class Running : Activity
{
    private double _distance; 

    public Running(DateTime date, int lengthMinutes, double distance)
        : base(date, lengthMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        if (_lengthMinutes == 0) return 0; 
        return (_distance / _lengthMinutes) * 60.0;
    }

    public override double GetPace()
    {
        if (_distance == 0) return 0; 
        return _lengthMinutes / _distance;
    }
}
