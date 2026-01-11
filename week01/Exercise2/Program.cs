using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        // Variables to store the letter grade and sign
        string letter = "";
        string sign = "";

        // Determine the letter grade based on percentage
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Get the last digit of the percentage
        int lastDigit = percent % 10;

        // Determine the sign (+ or -) based on the last digit
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // Handle exceptions for grades that cannot have signs
        if (letter == "A" && sign == "+")
        {
            sign = ""; // There is no A+ grade
        }

        if (letter == "F")
        {
            sign = ""; // There is no F+ or F- grade
        }

        // Display the final grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Display pass or fail message
        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}
