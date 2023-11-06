using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator prompt = new PromptGenerator();
        Journal journal = new Journal();
        Console.WriteLine();
        string menuSelection; // For user menu selection.
        int menuNumber = 0;

        // Create menu for user interface. User can write, display entries, load file, save file, or quit.
        do{
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write Journal Entry");
            Console.WriteLine("2. Display Journal Entries");
            Console.WriteLine("3. Save File");
            Console.WriteLine("4. Load File");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            menuSelection = Console.ReadLine();
            Console.WriteLine();
            // Ensure selected string is a digit beteen 1-5 for valid entry.
            // If not digit user will be prompted to enter a number between 1-5 and will be return to main menu.
            bool isInt = menuSelection.All(char.IsDigit);
            if (isInt == true)
            {
                menuNumber = int.Parse(menuSelection);
                if (menuNumber > 0 && menuNumber < 6)
                {
                    // Write Journal Entry
                    if (menuNumber == 1)
                    {
                        Entry entry = new Entry();
                        entry._date = DateTime.Now;
                        entry._promptText = "Journal Topic: " + prompt.GetRandomPrompt();
                        Console.WriteLine($"{entry._date.ToShortDateString()}");
                        Console.WriteLine($"Journal Topic: {entry._promptText}");
                        Console.Write("Journal Entry: ");
                        entry._entryText = Console.ReadLine();
                        entry._entryText = "Journal Entry: " + entry._entryText;
                        journal.AddEntry(entry);
                    }
                    // Display Journal Entries
                    else if (menuNumber == 2)
                    {
                        journal.DisplayAll();
                    }
                    // Save File
                    else if (menuNumber == 3)
                    {
                        journal.SaveToFile();
                    }
                    // Load File
                    else if (menuNumber == 4)
                    {
                        journal.LoadFromFile();
                    }
                }
                else
                {
                Console.WriteLine("Please enter a value between 1 and 5.");
                } 
            }
            else
            {
                Console.WriteLine("Please enter a value between 1 and 5.");
            }
        // Quit if 5 selected.
        } while (menuNumber != 5);
    }
}