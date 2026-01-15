using System;



class Program
{
    static void Main(string[] args)
    {
        Resume myResume = new Resume();
        myResume._name = "John Doe";

        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Tech Corp";
        job1._startDate = 2019;
        job1._endDate = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Senior Developer";
        job2._company = "Innovate LLC";
        job2._startDate = 2022;
        job2._endDate = 2023;

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }   
}