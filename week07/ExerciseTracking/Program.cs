using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running runningActivity = new Running(new DateTime(2025, 4, 16), 30, 3.0); 
        Cycling cyclingActivity = new Cycling(new DateTime(2025, 4, 17), 45, 15.0); 
        Swimming swimmingActivity = new Swimming(new DateTime(2025, 4, 18), 60, 40); 

        activities.Add(runningActivity);
        activities.Add(cyclingActivity);
        activities.Add(swimmingActivity);

        Console.WriteLine("Exercise Activity Summaries:");
        Console.WriteLine("----------------------------");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine(); 
        }

        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();    
    }
}