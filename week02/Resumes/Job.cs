using System;
public class Job
{
    // Member variables (fields)
    private string _company;
    private string _jobTitle;
    private int _startYear;
    private int _endYear;

    public Job()
    {
    }

    // Properties (optional, but good practice)
    public string Company 
    { 
        get { return _company; } 
        set { _company = value; } 
    }
    
    public string JobTitle 
    { 
        get { return _jobTitle; } 
        set { _jobTitle = value; } 
    }
    
    public int StartYear 
    { 
        get { return _startYear; } 
        set { _startYear = value; } 
    }
    
    public int EndYear 
    { 
        get { return _endYear; } 
        set { _endYear = value; } 
    }

    // Display method
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}