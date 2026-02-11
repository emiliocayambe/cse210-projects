public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() : base(
        "Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This can help you recognize the power you have and how you can use it in other aspects of your life.",
        0)
    {
        _prompts = new List<string>
        {
            "Think of a time when you overcame a difficult challenge.",
            "Recall a moment when you felt truly proud of yourself.",
            "Remember a situation where you helped someone in need.",
            "Reflect on a time when you learned something valuable from a mistake."
        };

        _questions = new List<string>
        {
            "What did you learn from this experience?",
            "How did this experience shape who you are today?",
            "What strengths did you demonstrate during this experience?",
            "How can you apply what you learned from this experience to future challenges?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Get ready to start the reflecting activity...");
        ShowSpinner(3); // Show spinner for 3 seconds before starting

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("Take a moment to think about this experience...");

        ShowSpinner(5); // Show spinner for 5 seconds while user reflects

        foreach (string question in _questions)
        {
            Console.WriteLine(question);
            ShowSpinner(5); // Show spinner for 5 seconds while user reflects on each question
        }

        Console.WriteLine("Great job! You've completed the reflecting activity.");
        DisplayEndingMessage();
    }
}