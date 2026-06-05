using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
 public class Video
    {
        // Private fields
        private string _title;
        private string _author;
        private int _lengthInSeconds;
        private List<Comment> _comments;

        // Constructor
        public Video(string title, string author, int lengthInSeconds)
        {
            _title = title;
            _author = author;
            _lengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }

        // Method to add a comment to the video
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        // Method to return the number of comments
        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        // Method to display video details and all its comments
        public void DisplayVideoInfo()
        {
            Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Length: {_lengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in _comments)
            {
                comment.DisplayComment();
            }

            Console.WriteLine(); // Blank line for spacing between videos
        }
    }
}