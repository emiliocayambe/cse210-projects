public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by prompting you to list as many items as you can in a certain category.", 0)
    {
        _prompts = new List<string>
        {
            "List as many things as you are grateful for.",
            "List as many people who have positively impacted your life.",
            "List as many personal strengths you have.",
            "List as many happy memories you can recall."
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Get ready to start the listing activity...");
        ShowSpinner(3); // Show spinner for 3 seconds before starting

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("You have 30 seconds to list as many items as you can...");

        _count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(30);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                Console.ReadLine(); // Read user input
                _count++;
            }
        }

        Console.WriteLine($"You listed {_count} items. Great job!");
        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(30);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    items.Add(input);
                }
            }
        }

        return items;
    }


}