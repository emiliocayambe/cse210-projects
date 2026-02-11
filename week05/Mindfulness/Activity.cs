public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} activity!");
        Console.WriteLine(_description);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"You have completed the {_name} activity. Well done!");
    }   

    public void ShowSpinner(int durationInSeconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        int spinnerIndex = 0;
        int totalTime = 0;

        while (totalTime < durationInSeconds * 1000)
        {
            Console.Write(spinner[spinnerIndex] + "\r");
            spinnerIndex = (spinnerIndex + 1) % spinner.Length;
            Thread.Sleep(250); // Update spinner every 250 milliseconds
            totalTime += 250;
        }
    }

    public void ShowCountdown(int durationInSeconds)
    {
        for (int i = durationInSeconds; i > 0; i--)
        {
            Console.Write(i + " seconds remaining...\r");
            Thread.Sleep(1000); // Wait for 1 second
        }
        Console.WriteLine("Time's up!                ");
    }

}