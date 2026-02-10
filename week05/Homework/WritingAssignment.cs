public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        // Set the specific properties for the WritingAssignment class
        _title = title;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetWritingInformation()
    {
        return $"{GetTitle()} by {GetStudentName()}";
    }
}