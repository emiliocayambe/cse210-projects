using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // Master list of realistic, non-robotic prompts
    private List<string> _allPrompts = new List<string>
    {
        "What was the most awkward or funny thing you saw today?",
        "If today was a movie, what would the title be?",
        "Who was the most interesting person you talked to today?",
        "What was the biggest waste of time today?",
        "What is one thing you are looking forward to tomorrow?",
        "Describe the best meal you had today.",
        "What conversation is still stuck in your head?"
    };

    // Tracks prompts that haven't been shown in the current cycle
    private List<string> _unusedPrompts = new List<string>();

    public string GetRandomPrompt()
    {
        // If we've used all prompts, we refill the list to start over
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_allPrompts);
        }

        Random random = new Random();
        int index = random.Next(_unusedPrompts.Count);
        string selectedPrompt = _unusedPrompts[index];

        // EXCEEDING REQUIREMENTS: Removing the prompt after use so it doesn't repeat 
        // until the entire list has been cycled through.
        _unusedPrompts.RemoveAt(index);

        return selectedPrompt;
    }
}