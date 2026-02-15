using System;
using System.Collections.Generic;
using System.IO;

// The GoalManager class acts as the "brain" of the application.
// It handles user interaction, goal management, and data persistence.
public class GoalManager
{
    private List<Goal> _goals = new List<Goal>(); // Stores all goal objects (Simple, Eternal, Checklist)
    private int _score = 0;                       // Keeps track of the user's total accumulated points

    // Constructor to initialize the internal list and player score
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Main control loop that provides the menu interface to the user
    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            // Requirement: Always display the current score and rank before menu options
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoalDetails();
            else if (choice == "3") SaveGoals();
            else if (choice == "4") LoadGoals();
            else if (choice == "5") RecordEvent();
        }
    }

    // Displays the current score and the gamified level/rank based on points
    public void DisplayPlayerInfo()
    {
        // Gamification enhancement: Ranking system
        string level = "Beginner";
        if (_score >= 2000) level = "Grandmaster";
        else if (_score >= 1000) level = "Warrior";
        else if (_score >= 500) level = "Apprentice";

        Console.WriteLine($"\n>>> Current Score: {_score} - Level: {level} <<<");
    }

    // Lists only the names/status of goals, primarily used during event recording
    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // Iterates through all goals and prints their full details using polymorphism
    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    // Handles the logic for creating different types of goals based on user input
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:\n  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int pts = int.Parse(Console.ReadLine());

        // Factory-like logic to instantiate the correct derived class
        if (type == "1") _goals.Add(new SimpleGoal(name, desc, pts));
        else if (type == "2") _goals.Add(new EternalGoal(name, desc, pts));
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, pts, target, bonus));
        }
    }

    // Records an accomplishment, updates the score, and handles special bonuses
    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("\nWhich goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        Goal selected = _goals[index];
        selected.RecordEvent(); // Polymorphic call to the specific goal's event logic
        
        // Visual feedback for user engagement (Creativity requirement)
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=========================================");
        Console.WriteLine("       GOAL PROGRESS RECORDED!           ");
        Console.WriteLine("=========================================");
        Console.ResetColor();

        int pointsEarned = selected.GetPoints();
        
        // Special logic for checklist bonus using type checking
        if (selected is ChecklistGoal cg && cg.IsComplete()) 
        {
            pointsEarned += cg.GetBonus();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⭐ BONUS UNLOCKED! YOU ARE AMAZING! ⭐");
            Console.ResetColor();
        }

        _score += pointsEarned;
        Console.WriteLine($"\nYou earned {pointsEarned} points!");
        Console.WriteLine($"Total Score: {_score}");
    }

    // Saves the current score and all goal data into a text file
    public void SaveGoals()
    {
        Console.Write("What is the filename? ");
        string file = Console.ReadLine();
        using (StreamWriter sw = new StreamWriter(file))
        {
            sw.WriteLine(_score); // Score is saved on the first line
            foreach (var g in _goals) sw.WriteLine(g.GetStringRepresentation());
        }
    }

    // Loads goal data from a text file and reconstructs the objects (Factory Pattern)
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename)) return;

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':'); // Separates class name from data
            string goalType = parts[0];
            string[] d = parts[1].Split(',');    // CSV-style data parsing

            if (goalType == "SimpleGoal")
                _goals.Add(new SimpleGoal(d[0], d[1], int.Parse(d[2]), bool.Parse(d[3])));
            else if (goalType == "EternalGoal")
                _goals.Add(new EternalGoal(d[0], d[1], int.Parse(d[2])));
            else if (goalType == "ChecklistGoal")
                // Parsing logic to restore current progress for checklist goals
                _goals.Add(new ChecklistGoal(d[0], d[1], int.Parse(d[2]), int.Parse(d[4]), int.Parse(d[3]), int.Parse(d[5])));
        }
    }
}