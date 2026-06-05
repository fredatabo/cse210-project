using System;

namespace YouTubeVideos 
{
class Program
{
    static void Main(string[] args)
        {
            // Create a list to hold all videos
            List<Video> videos = new List<Video>();

            // ----- Video 1 -----
           // ----- Video 1 -----
Video video1 = new Video("Mastering Async/Await in C#", "CodeWithSarah", 1845);
video1.AddComment(new Comment("Tom", "Finally someone who explains this clearly!"));
video1.AddComment(new Comment("Rachel", "The deadlock example saved my project."));
video1.AddComment(new Comment("Marcus", "Can you cover cancellation tokens next?"));
video1.AddComment(new Comment("Linda", "Best explanation on YouTube. Subscribed!"));
video1.AddComment(new Comment("James", "I've watched 5 other videos, this one wins."));
videos.Add(video1);

// ----- Video 2 -----
Video video2 = new Video("SOLID Principles in 20 Minutes", "DesignPatternsDaily", 1200);
video2.AddComment(new Comment("Sophia", "Why didn't my college teach this?"));
video2.AddComment(new Comment("David", "The Liskov example was brilliant!"));
video2.AddComment(new Comment("Emma", "Clean code finally makes sense."));
video2.AddComment(new Comment("Carlos", "Going to refactor my whole project now."));
videos.Add(video2);

// ----- Video 3 -----
Video video3 = new Video("Git Workflow for Teams", "DevOpsPro", 2100);
video3.AddComment(new Comment("Oliver", "We're switching to this workflow tomorrow"));
video3.AddComment(new Comment("Zoe", "The rebase vs merge explanation was perfect"));
video3.AddComment(new Comment("Liam", "My merge conflicts are finally under control"));
video3.AddComment(new Comment("Ava", "Straight to my team's Slack channel"));
video3.AddComment(new Comment("Ethan", "This should be mandatory training for juniors"));
videos.Add(video3);

// ----- Video 4 -----
Video video4 = new Video("Database Indexing Explained", "DataEngineerZone", 1560);
video4.AddComment(new Comment("Maya", "My queries went from 10 seconds to 0.1!"));
video4.AddComment(new Comment("Kevin", "The B-tree visualization was super helpful"));
video4.AddComment(new Comment("Nina", "I've been afraid of indexes until now"));
video4.AddComment(new Comment("Brian", "Covered vs non-covered finally makes sense"));
video4.AddComment(new Comment("Patricia", "Watching this during my lunch break. Worth it!"));
videos.Add(video4);

            // Iterate through the list and display each video's info
            foreach (Video video in videos)
            {
                video.DisplayVideoInfo();
            }

            // Keep console window open (only needed if running without debugger)
            // Console.ReadLine();
        }
    

}
}