using System;

// Represents a goal that is never fully completed but provides points each time it is recorded.
// Examples include daily scripture study, exercising, or any habit the user wants to maintain.
public class EternalGoal : Goal
{
    // Constructor that passes information to the base Goal class
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points) 
    { 
    }

    // Records the event. For Eternal Goals, no internal state (like a counter or boolean) 
    // needs to change because the goal is designed to repeat indefinitely.
    public override void RecordEvent() 
    { 
        // Eternal goals do not change state, they just exist to grant points via GoalManager.
    }

    // Always returns false because an eternal goal is, by definition, never "finished".
    public override bool IsComplete() => false;

    // Returns a string representation of the goal for file storage using comma delimiters.
    public override string GetStringRepresentation() => $"EternalGoal:{_shortName},{_description},{_points}";
}