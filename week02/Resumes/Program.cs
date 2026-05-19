using System;

class Program
{
    static void Main(string[] args)
    {
        // Create first job
        Job job1 = new Job();
        job1.JobTitle = "Software Engineer";  
        job1.Company = "Microsoft";           
        job1.StartYear = 2019;               
        job1.EndYear = 2022;                 
        
        // Create second job
        Job job2 = new Job();
        job2.JobTitle = "Manager";            
        job2.Company = "Apple";              
        job2.StartYear = 2022;               
        job2.EndYear = 2023;                 
        
        // Create resume
        Resume myResume = new Resume();
        myResume.PersonName = "John Doe";    
        
        // Add jobs to resume
        myResume.Jobs.Add(job1);             
        myResume.Jobs.Add(job2);             
        
        // Test accessing job title through resume
        Console.WriteLine(myResume.Jobs[0].JobTitle);  
        
        Console.WriteLine("\n---\n");
        
        // Display full resume
        myResume.Display();


    }
}