public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by guiding you through a series of deep breaths. Follow the prompts to breathe in, hold, and breathe out.",
        0)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Get ready to start the breathing activity...");
        ShowSpinner(3); // Show spinner for 3 seconds before starting

        Console.WriteLine("Breathe in... (4 seconds)");
        ShowCountdown(4);
        Console.WriteLine("Hold... (7 seconds)");
        ShowCountdown(7);
        Console.WriteLine("Breathe out... (8 seconds)");
        ShowCountdown(8);

        Console.WriteLine("Great job! You've completed the breathing exercise.");
        DisplayEndingMessage();
    }

}