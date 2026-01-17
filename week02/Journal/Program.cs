/*
 * EXCEEDING REQUIREMENTS:
 * To improve the user experience, I modified the PromptGenerator class to prevent 
 * repetitive questions. The system now tracks which prompts have been used and 
 * ensures that the user cycles through the entire list before seeing the same 
 * question again. This makes the journaling process feel more dynamic and natural.
 */

 
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        while (true)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("1. Write a new journal entry");
            Console.WriteLine("2. Display all journal entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("Your entry: ");
                string entryText = Console.ReadLine();
                Entry entry = new Entry
                {
                    _date = DateTime.Now.ToString("yyyy-MM-dd"),
                    _promptText = prompt,
                    _entryText = entryText
                };
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                try
                {
                    journal.SaveToFile(filename);
                    string fullPath = Path.GetFullPath(filename);
                    Console.WriteLine($"Journal saved to '{fullPath}'.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving file: {ex.Message}\n");
                }
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                try
                {
                    string fullPath = Path.GetFullPath(filename);
                    Console.WriteLine($"(Loading from: {Environment.CurrentDirectory})");
                    journal.LoadFromFile(filename);
                    Console.WriteLine($"Journal loaded from '{fullPath}':\n");
                    // Show the loaded entries immediately so the user sees them
                    journal.DisplayAll();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"File '{filename}' not found in {Environment.CurrentDirectory}.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading file: {ex.Message}\n");
                }
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}