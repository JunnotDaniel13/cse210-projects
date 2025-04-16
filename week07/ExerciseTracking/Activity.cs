public abstract class Activity
{
    protected DateTime _date;
    protected int _lengthMinutes; 

    public Activity(DateTime date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }


    public abstract double GetDistance(); 
    public abstract double GetSpeed();    
    public abstract double GetPace();    


    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_lengthMinutes} min) - Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
