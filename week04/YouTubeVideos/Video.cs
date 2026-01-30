using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comments> _comments;   


    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comments>();
    }

    public void AddComment(Comments comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public List<Comments> GetComments()
    {
        return _comments;
    }

    public string GetTitle() => _title;
    public string GetAuthor() => _author;
    public int GetLengthInSeconds() => _lengthInSeconds;   
    public List<Comments> GetCommentList() => _comments;
}
