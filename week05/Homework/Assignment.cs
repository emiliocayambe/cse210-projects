public class Assignment
{
 private string _studentName;
 private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    //we will get the student name and topic of the assignment
    public string GetStudentName()
    {
        return _studentName;
    }
    public string GetTopic()
    {
        return _topic;
    }   
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}