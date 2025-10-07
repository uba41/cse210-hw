using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();
        
        // Video 1
        Video video1 = new Video("Understanding LINQ in C#", "TechWithTim", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Helped me a lot, thanks."));
        video1.AddComment(new Comment("Charlie", "Can you make one for async/await?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Top 10 JavaScript Tips", "DevSimplified", 480);
        video2.AddComment(new Comment("Daisy", "Exactly what I needed."));
        video2.AddComment(new Comment("Ethan", "Love your content."));
        video2.AddComment(new Comment("Fay", "Please do a part 2!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("How to Use Unity", "GameMakerJoe", 720);
        video3.AddComment(new Comment("Gina", "Super helpful tutorial."));
        video3.AddComment(new Comment("Henry", "Can’t wait to build my own game!"));
        video3.AddComment(new Comment("Isla", "You made it so easy."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Intro to Python", "CodeAcademy", 900);
        video4.AddComment(new Comment("Jack", "Simple and clear."));
        video4.AddComment(new Comment("Karen", "Great for beginners."));
        video4.AddComment(new Comment("Liam", "More videos like this please!"));
        videos.Add(video4);

        // Display the video information
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }    
}