using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    private string _personName;
    private List<Job> _jobs;

    // Constructor to initialize the jobs list
    public Resume()
    {
        _jobs = new List<Job>();
    }

    // Properties
    public string PersonName
    {
        get { return _personName; }
        set { _personName = value; }
    }
    
    public List<Job> Jobs
    {
        get { return _jobs; }
        set { _jobs = value; }
    }

    // Display method
    public void Display()
    {
        Console.WriteLine($"Name: {_personName}");
        Console.WriteLine("Jobs:");
        
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}