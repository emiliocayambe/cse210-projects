using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/**
 * The ScriptureLibrary class handles all file operations.
 * It follows the Single Responsibility Principle by separating 
 * file parsing from the game logic.
 */
class ScriptureLibrary
{
    private string _filename;

    public ScriptureLibrary(string filename)
    {
        _filename = filename;
    }

    /**
     * Reads the file and returns one random Scripture object.
     */
    public Scripture GetRandomScripture()
    {
        if (!File.Exists(_filename))
        {
            // Fallback in case the file is missing
            return new Scripture(new Reference("Error", 404, 1), "File not found.");
        }

        string[] lines = File.ReadAllLines(_filename);
        if (lines.Length == 0) return null;

        // Pick a random line
        Random rand = new Random();
        string selectedLine = lines[rand.Next(lines.Length)];
        
        // Parse the line
        string[] parts = selectedLine.Split('|').Select(p => p.Trim()).ToArray();
        
        string book = parts[0];
        int chapter = int.Parse(parts[1]);
        int startVerse = int.Parse(parts[2]);
        string text = "";
        Reference reference;

        // Check if there's a range of verses or a single one
        if (int.TryParse(parts[3], out int endVerse))
        {
            reference = new Reference(book, chapter, startVerse, endVerse);
            text = parts[4];
        }
        else
        {
            reference = new Reference(book, chapter, startVerse);
            text = parts[3];
        }

        // Return a fully formed Scripture object
        return new Scripture(reference, text);
    }
}