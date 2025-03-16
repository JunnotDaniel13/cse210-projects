using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._company = "Apple";
        job1._jobTitle = "Full stack developer";
        job1._startYear = 2025;
        job1._endYear = 2030;

        Job job2 = new Job();

        job2._company = "Unknown";
        job2._jobTitle = "Business Owner";
        job2._startYear = 2030;
        job2._endYear = 2200;


        Resume myResume = new Resume();

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume._name = "Jerenason Junnot Daniel";

        myResume.Display();
    }
}