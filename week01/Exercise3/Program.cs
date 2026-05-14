using System;

class Program
{
    static void Main(string[] args)
    {
         Random randomGenerator = new Random();
        bool playAgain = true;
        
        // Stretch Challenge: Keep track of total games played 
        int totalGamesPlayed = 0;
        
        while (playAgain)
        {
            // Core Requirement 3: Generate random number from 1 to 100
            int magicNumber = randomGenerator.Next(1, 101);
            
            // Stretch Challenge: Track guesses per game
            int numberOfGuesses = 0;
            int guess = 0;
            
            // Core Requirement 2: Loop until correct guess
            while (guess != magicNumber)
            {
                // Core Requirement 1 & 2: Ask for guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                
                numberOfGuesses++; // Increment guess counter
                
                // Core Requirement 1: Give hints
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }
            
            // Stretch Challenge: Display number of guesses
            Console.WriteLine($"It took you {numberOfGuesses} guesses to find the magic number!");
            
            totalGamesPlayed++;
            
            // Stretch Challenge: Ask to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            
            if (response != "yes")
            {
                playAgain = false;
                Console.WriteLine($"Thanks for playing! You played {totalGamesPlayed} game(s).");
            }
            else
            {
                Console.WriteLine(); // Added blank line for spacing between games
            }
        }
    }
}