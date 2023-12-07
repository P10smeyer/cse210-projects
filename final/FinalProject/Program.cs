using System;

class Program
{
    static void Main(string[] args)
    {
        bool keepGoing = true;
        int mainMenuSelection;
        BudgetManager budgetManager = new BudgetManager();
        // Keep circling to the main menu unless the user selects '8' to quit the program.
        while (keepGoing)
        {
            Menu menu = new Menu();
            mainMenuSelection = menu.MainMenuSelection(8);
            // '1. Set Your Monthly Budget' is selected by the user.
            if (mainMenuSelection == 1)
            {
                budgetManager.CreateMonthlyBudget();
            }
            // '2. See Budget Status' is selected by the user.
            else if (mainMenuSelection == 2)
            {
                budgetManager.BudgetStatus();
            }
            // '8. Quit' is selected by the user.
            else if (mainMenuSelection == 8)
            {
                keepGoing = false;
                Console.WriteLine("Thanks for using the budgeting program. Hope to see you soon!");
                Console.WriteLine();
            }
        }
    }
}