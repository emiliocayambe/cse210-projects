using System;

class Program
{
    static void Main(string[] args)
    {
        // make list of videos
        var videos = new List<Video>();

        // create first video and add comments
        var video1 = new Video("C# Tutorial", "John Doe", 600);
        video1.AddComment(new Comments("Alice", "Great tutorial!"));
        video1.AddComment(new Comments("Bob", "Very helpful, thanks!"));
        videos.Add(video1);

        // create second video and add comments
        var video2 = new Video("Learn Python", "Jane Smith", 800);
        video2.AddComment(new Comments("Charlie", "I love Python!"));
        video2.AddComment(new Comments("Dave", "This was very informative."));
        videos.Add(video2);

        // create third video and add comments
        var video3 = new Video("JavaScript Basics", "Emily Johnson", 500);
        video3.AddComment(new Comments("Eve", "Nice introduction to JS.")); 
        video3.AddComment(new Comments("Frank", "Looking forward to more videos."));
        video3.AddComment(new Comments("Grace", "Can you cover more advanced topics?"));   
        videos.Add(video3);

        // display video information and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length (seconds): {video.GetLengthInSeconds()}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }

    }
}