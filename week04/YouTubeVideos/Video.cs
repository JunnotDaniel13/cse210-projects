
public class Video
{
    private string _title;
    private string _author;
    private int _lengthSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _lengthSeconds = length;
        _comments = new List<Comment>(); 
    }

    public void AddComment(string commenterName, string commentText)
    {
        Comment newComment = new Comment(commenterName, commentText);
        _comments.Add(newComment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}"); // Uses the method
    }

    public void DisplayComments()
    {
        if (_comments.Count > 0)
        {
            Console.WriteLine("Comments:");
            foreach (Comment comment in _comments)
            {
                comment.Display(); 
            }
        }
        else
        {
            Console.WriteLine("No comments yet.");
        }
    }
}
