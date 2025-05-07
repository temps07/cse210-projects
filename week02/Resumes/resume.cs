using System;

public class Resume
{
    public string _name = "Temple Ohanu";
    public List<Job> _jobList = new List<Job>();
    public Job _job1 = new Job();
    public Job _job2 = new Job();
    public void DisplayResume()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine("Jobs:");
             // Notice the use of the custom data type "Job" in this loop
            foreach (Job job in _jobList)
            {
            // This calls the Display method on each job
                job.DisplayJobDetails();
            }
        }
}