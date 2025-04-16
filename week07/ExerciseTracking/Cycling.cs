public class Cycling : Activity
{
    private double _speed; 

    public Cycling(DateTime date, int lengthMinutes, double speed)
        : base(date, lengthMinutes)
    {
        _speed = speed;
    }


    public override double GetDistance()
    {
        return (_speed / 60.0) * _lengthMinutes;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        if (_speed == 0) return 0; 
        return 60.0 / _speed;
    }
}
