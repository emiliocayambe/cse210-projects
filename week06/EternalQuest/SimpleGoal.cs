using System;

// Represents a one-time goal that is finished after being recorded once.
// Once completed, it stays in the "complete" state indefinitely.
public class SimpleGoal : Goal
{
    private bool _isComplete; // Tracks whether the goal has been finished

    // Constructor that initializes the simple goal.
    // Includes an optional parameter to restore completion state from a file.
    public SimpleGoal(string name, string description, int points, bool isComplete = false) 
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // Implementation of the abstract method: sets the goal as complete when recorded.
    public override void RecordEvent() => _isComplete = true;

    // Returns the current completion status.
    public override bool IsComplete() => _isComplete;

    // Provides a comma-separated string for file storage, including the boolean state.
    public override string GetStringRepresentation() => $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
}