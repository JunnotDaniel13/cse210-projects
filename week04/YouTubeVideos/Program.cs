using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video(
            "C# Tutorial for Beginners",
            "Tech Explained",
            600
        );
        Video video2 = new Video(
            "Funny Cat Compilation",
            "Cats R Us",
            320
        );
        Video video3 = new Video(
            "How to Bake Sourdough",
            "Baker Bob",
            1250
        );
        Video video4 = new Video(
            "Introduction to Abstraction",
            "Code Concepts",
            480
        );

        video1.AddComment("Alice", "Great explanation, thanks!");
        video1.AddComment("Bob", "Helped me understand classes.");
        video1.AddComment("Charlie", "A bit fast, but useful.");

        video2.AddComment("David", "LOL, the grey cat is hilarious.");
        video2.AddComment("Eve", "My cat does the same thing!");
        video2.AddComment("Frank", "Needed this laugh today.");
        video2.AddComment("Grace", "So cute!");

        video3.AddComment("Heidi", "My starter isn't active enough.");
        video3.AddComment("Ivan", "Perfect loaf first try, thanks!");
        video3.AddComment("Judy", "What temperature do you bake at?");

        video4.AddComment("Mallory", "Clear definition of abstraction.");
        video4.AddComment("Oscar", "Good real-world examples.");
        video4.AddComment("Peggy", "Why is abstraction important?");

        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        Console.WriteLine("--- YouTube Video Details ---");
        foreach (Video video in videos)
        {
            Console.WriteLine("\n------------------------------");
            video.DisplayVideoDetails();
            video.DisplayComments();
            Console.WriteLine("------------------------------");
        }
    }
}