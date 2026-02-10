public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {

        // Set the specific properties for the MathAssignment class
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetTextbookSection()
    {
        return _textbookSection;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}