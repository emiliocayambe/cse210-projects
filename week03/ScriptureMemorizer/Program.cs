using System;

/**

 W03 - Scripture Memorizer application
 Author: Emilio Cayambe
 Date: 2026-01-23

 * Program Class: The entry point for the Scripture Memorizer application.
 * * DESIGN DECISION: This version incorporates a 'ScriptureLibrary' class to handle 
 * file I/O operations. By separating the loading logic from the Scripture class.
 * * NEW FEATURE: The application now supports multiple scriptures in the source file
 * and will select one at random upon startup.
 
 */
class Program
{
    static void Main(string[] args)
    {
        // Initialize the library with the path to the text file
        ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");

        // The library handles the random selection and object creation
        // This keeps the Main method clean and focused on the game flow
        Scripture scripture = library.GetRandomScripture();

        // Safety check to ensure the file was found and parsed correctly
        if (scripture == null)
        {
            Console.WriteLine("Error: Could not load the scripture library. Check your file path.");
            return;
        }

        // Main game loop
        while (true)
        {
            Console.Clear();
            
            // Display the current state of the scripture (Reference + words/underscores)
            Console.WriteLine(scripture.GetDisplayText());
            
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
            string input = Console.ReadLine();

            // Exit condition
            if (input.ToLower() == "quit")
            {
                break;
            }

            // Logic to hide a new set of random words
            scripture.HideRandomWord();

            // Check if all words are hidden to end the program automatically
            if (scripture.isCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden! Memory challenge complete.");
                break;
            }
        }
    }
}