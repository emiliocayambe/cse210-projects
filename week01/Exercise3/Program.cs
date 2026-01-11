using System;

class Program
{
    static void Main(string[] args)
    {
        // play again
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Use a random number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int count = 1;

            // We could also use a do-while loop here...
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                    count ++;
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                    count++;
                }
                else
                {
                    Console.WriteLine("You guessed it! you");
                    Console.WriteLine($"You guessed it in { count } guesses");
                 
                }
            }
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing!");

    }
}