public class Comment
{
    public string _commenterName;
    public string _commentText;

    public Comment(string name, string text)
    {
        _commenterName = name;
        _commentText = text;
    }

    public void Display()
    {
        Console.WriteLine($"  - {_commenterName}: \"{_commentText}\"");
    }
}
