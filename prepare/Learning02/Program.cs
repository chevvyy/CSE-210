using System;

class Program
{
    static void Main()
    {
        var job1 = new Job();
        job1._jobTitle = "Engineer";
        job1._company = "Apple";
        job1._startYear = 2017;
        job1._endYear = 2021;

        var job2 = new Job();
        job2._jobTitle = "Team Lead";
        job2._company = "Google";
        job2._startYear = 2021;
        job2._endYear = 2024;

        var myResume = new Resume();
        myResume._name = "Devin";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}