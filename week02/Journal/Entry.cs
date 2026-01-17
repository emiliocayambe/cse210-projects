using System;

public class Entry
{
    public string _date;
    public string _promptText; // Fixed the double 't' for consistency
    public string _entryText;

    // This method handles the specific formatting for a single entry
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine("-------------------------------------------");
    }
}