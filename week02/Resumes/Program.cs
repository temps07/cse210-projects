using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2007;
        job1._endYear = 2023;

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Cyber Security";
        job2._startYear = 2020;
        job2._endYear = 2022;

        Resume resume = new Resume();
        resume._jobList.Add(job1);
        resume._jobList.Add(job2);
        resume.DisplayResume();
    }
}