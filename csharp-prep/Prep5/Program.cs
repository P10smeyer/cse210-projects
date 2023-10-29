using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int numberSquared = SquareNumber(number);
        DisplayResult(name, numberSquared);

        // Displays Welcome Message.
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        // Prompt user for name and return a string name.
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        // Prompt user for their favorite number and return a int number.
        static int PromptUserNumber()
        {
            Console.Write("What is your favorite number? ");
            int favoriteNumber = int.Parse(Console.ReadLine());
            return favoriteNumber;
        }

        // Pass in number as a parameter and square the value. Return int number.
        static int SquareNumber(int number)
        {
            int numberSquared = number * number;
            return numberSquared;
        }

        // Display the user name and favorite number.
        static void DisplayResult(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, The square of your favorite number is {squaredNumber}.");
        }
    }
}