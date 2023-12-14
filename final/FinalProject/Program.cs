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
            mainMenuSelection = menu.MainMenuSelection(10);
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
            // '3. Add a Budget Category' is selected by the user.
            else if (mainMenuSelection == 3)
            {
                budgetManager.AddBudgetCategory();
            }
            // '4. Remove a Budget Category' is selected by the user.
            else if (mainMenuSelection == 4)
            {
                budgetManager.RemoveBudgetCategory();
            }
            // '5. Display Budget Categories' is selected by the user.
            else if (mainMenuSelection == 5)
            {
                budgetManager.DisplayBudgetCategories();
            }
            // '6. Record a Transaction' is selected by the user.
            else if (mainMenuSelection == 6)
            {
                Menu transactionsMenu = new Menu();
                int transactionMenuSelection = transactionsMenu.RecordTransactionMenu(3);
                budgetManager.Transactions(transactionMenuSelection);
            }
            // '7. Load Budget' is selected by the user.
            else if (mainMenuSelection == 7)
            {
                budgetManager.LoadMonthlyBudget();
            }
            // '8. Save Budget' is selected by the user.
            else if (mainMenuSelection == 8)
            {
                budgetManager.SaveMonthlyBudget();
            }
            // '9. Reset Budget' is selected by the user.
            else if (mainMenuSelection == 9)
            {
                budgetManager.ResetBudget();
            }
            // '8. Quit' is selected by the user.
            else if (mainMenuSelection == 10)
            {
                keepGoing = false;
                Console.WriteLine("Thanks for using the budgeting program. Hope to see you soon!");
                Console.WriteLine();
            }
        }
    }
}