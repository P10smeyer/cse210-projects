using System;

class Program
{
    static void Main(string[] args)
    {   
        bool playAgain = true; // To determine if the user wants to keep playing.
        int guessCount = 0; // Counts the number of guesses.
        do
        {
            // Was used for user to enter in magic number.
            // Console.Write("What is the magic number? "); 
            // Generate a magic number.
            // int magicNumber = int.Parse(Console.ReadLine());

            // Generate random magic number.
            Console.WriteLine();
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            int guess; // The guess by the user for the magic number.
            
            do
            {
                Console.Write("Try guessing a random number from 1-100: ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
                // User instructed to guess higher, lower, or if they win if they want to play again.
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} tries!");
                    Console.Write("Do you want to play again ('yes' or 'no')? ");
                    string playMore = Console.ReadLine();
                    if (playMore.ToLower() == "no" || playMore.ToLower() == "n")
                    {
                        playAgain = false;
                    }
                    else
                    {
                        guessCount = 0; // Reset the guess count if they play again.
                    }
                }
            } while (guess != magicNumber);
        } while (playAgain == true);
    }
}