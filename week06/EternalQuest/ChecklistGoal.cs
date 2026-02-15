using System;

// Represents a goal that must be accomplished a certain number of times to be complete.
// Includes a bonus when the target is reached.
public class ChecklistGoal : Goal
{
    private int _amountCompleted; // Tracks how many times the goal has been done
    private int _target;          // The number of times required to finish
    private int _bonus;           // Extra points awarded upon reaching the target

    // Constructor to initialize the checklist goal with its specific attributes
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    // Increments the completion counter each time the event is recorded
    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    // Returns true if the goal has reached the target number of completions
    public override bool IsComplete() => _amountCompleted >= _target;

    // Provides a formatted string for display, including the current progress (e.g., 2/5)
    public override string GetDetailsString() => 
        $"{(IsComplete() ? "[X]" : "[ ]")} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";

    // Returns a string formatted for file storage using commas as delimiters
    public override string GetStringRepresentation() => 
        $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";

    // Getter to retrieve the bonus value for calculation in GoalManager
    public int GetBonus() => _bonus;
}