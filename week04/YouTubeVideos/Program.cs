using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Create and add first video
        Video video1 = new Video("C# Tutorial for Beginners", "Programming Guru", 1200);
        video1.AddComment(new Comment("JohnDoe", "Great tutorial!"));
        video1.AddComment(new Comment("JaneSmith", "Very helpful for my project."));
        video1.AddComment(new Comment("CodeNewbie", "Could you make one about classes?"));
        videos.Add(video1);

        // Create and add second video
        Video video2 = new Video("ASP.NET Core Crash Course", "Web Dev Master", 1800);
        video2.AddComment(new Comment("WebDev42", "Perfect timing for my new job!"));
        video2.AddComment(new Comment("SarahK", "Clear explanations, thank you."));
        video2.AddComment(new Comment("MikeT", "What about Blazor?"));
        video2.AddComment(new Comment("DevLearner", "Subscribed!"));
        videos.Add(video2);

        // Create and add third video
        Video video3 = new Video("Machine Learning Basics", "AI Enthusiast", 2400);
        video3.AddComment(new Comment("DataScientist", "Good overview of concepts."));
        video3.AddComment(new Comment("MLBeginner", "Which library do you recommend?"));
        video3.AddComment(new Comment("TechFan", "Looking forward to part 2!"));
        videos.Add(video3);

        // Create and add fourth video
        Video video4 = new Video("Unity Game Development", "GameMaker Pro", 1500);
        video4.AddComment(new Comment("IndieDev", "This saved me hours of research!"));
        video4.AddComment(new Comment("Gamer123", "When is the next tutorial coming?"));
        video4.AddComment(new Comment("GameDesigner", "Very comprehensive."));
        videos.Add(video4);

        // Iterate through each video and display information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetAllComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
            
            Console.WriteLine(); // Add a blank line between videos
        }
    }
}