using System;

// The base class for all goal types. 
// It is marked as 'abstract' because we should never create a generic "Goal" object;
// we only instantiate its specific derived types (Simple, Eternal, Checklist).
public abstract class Goal
{
    // Protected fields allow derived classes to access these attributes 
    // while keeping them hidden from the rest of the application (Encapsulation).
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Constructor to set up the basic information shared by all goal types.
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Abstract method: Each subclass must define its own logic for what happens 
    // when the user records progress on the goal.
    public abstract void RecordEvent();

    // Abstract method: Each subclass must determine if the criteria 
    // for completing the goal have been met.
    public abstract bool IsComplete();

    // Virtual method: Provides a default way to display goal details.
    // Subclasses like ChecklistGoal can override this to show extra info (like progress).
    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }

    // Abstract method: Forces each subclass to provide a specific string format 
    // for saving data to a text file.
    public abstract string GetStringRepresentation();

    // Simple getter to provide the points value to the GoalManager for score calculations.
    public int GetPoints() => _points;
}