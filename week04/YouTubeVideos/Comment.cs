using System;
using System.Collections.Generic;

namespace YouTubeVideos 
{
    // Class to represent a comment on a video
    public class Comment
    {
        // Private fields
        private string _commenterName;
        private string _commentText;

        // Constructor
        public Comment(string commenterName, string commentText)
        {
            _commenterName = commenterName;
            _commentText = commentText;
        }

        // Properties to access private fields
        public string CommenterName
        {
            get { return _commenterName; }
        }

        public string CommentText
        {
            get { return _commentText; }
        }

        // Method to display comment info
        public void DisplayComment()
        {
            Console.WriteLine($"   - {_commenterName}: \"{_commentText}\"");
        }
    }
}