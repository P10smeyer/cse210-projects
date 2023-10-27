using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();

        // Will continue to loop until a valid grade (between 0 and 100) is entered by the user.
        string letter;
        int grade = -1;
        while(grade < 0 || grade > 100)
        {
            Console.Write("What is your grade percentage? ");
            letter = Console.ReadLine(); // The letter grade.
            grade = int.Parse(letter); // The grade percentage.
            if(grade < 0 || grade > 100)
            {
                Console.WriteLine("Please enter a value greater than 0 and less than 100.");
            }
            
        }
        
        bool plus = true; // Determines if the grade has a plus or minus associated with it.
        bool noPlusMinus = false; // Will be used if there is not a plus or minus associated with the grade.

        // Will add a plus to the grade if ones digit is 7 or above, minus if less than 3,
        // otherwise no plus or minus with the grade.
        if (grade >=0)
        {
            int gradeRemainder = grade % 10;
            if (gradeRemainder < 3)
            {
                plus = false;
            }
            else if (gradeRemainder >= 7)
            {
                plus = true;
            }
            else {
                noPlusMinus = true;
            }
        }

        if (grade >= 90)
        {
            letter = "A";
        }

        else if (grade < 90 && grade >= 80)
        {
            letter = "B";
        }

        else if (grade < 80 && grade >= 70)
        {
            letter = "C";
        }
        
        else if (grade < 70 && grade >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        // Print grade and inform student if they passed the course or not.
        if (noPlusMinus == true)
        {
            Console.WriteLine($"Your course grade: {letter}");
        }
        else if (plus == true)
        {
            if (letter == "D" || letter == "C" || letter == "B" && plus == true)
            {
                Console.WriteLine($"Your course grade: {letter}+");
            }
            else 
            {
                Console.WriteLine($"Your course grade: {letter}");
            }
        }
        else if (plus == false)
        {
            if (letter == "D" || letter == "C" || letter == "B" || letter == "A")
            {
                Console.WriteLine($"Your course grade: {letter}-");
            }
            else 
            {
                Console.WriteLine($"Your course grade: {letter}");
            }
        }

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }

        else
        {
            Console.WriteLine("Sorry, you didn't pass the course. Don't give up.");
        }

        Console.WriteLine();
    }
}