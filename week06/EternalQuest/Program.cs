using System;

/*

    Autor: Emilio Cayambe

    Project: Eternal Quest - A Console-Based Goal Tracking RPG

  EXCEEDING REQUIREMENTS:
  1. Gamification Leveling System: Added a dynamic ranking system in DisplayPlayerInfo 
     that assigns titles (Beginner, Apprentice, Warrior, Grandmaster) based on the user's total score.
  2. Enhanced User Experience: Implemented console color schemes and clear-screen animations 
     during the RecordEvent process to provide visual feedback and celebrate goal achievements.
  3. Data Integrity: Enhanced the Load/Save system to handle complex data structures 
     efficiently, ensuring progress in ChecklistGoals is accurately preserved.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}