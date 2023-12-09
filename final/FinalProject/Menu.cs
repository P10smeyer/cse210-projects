public class Menu
{
    int _menuNumber; // Identifies valid user menu number selection.
    string _menuSelection; // Identifies user menu selection.
    string _transactionMenuSelection; // Identifies user menu selection when recording a transaction.
    bool keepGoing = true; // Determine if while loop should end.
    bool keepGoingTransactions = true; // Determine if while loop should end for transactions.

    // Main menu for the user to navigate budget options.
    public int MainMenuSelection(int menuLength)
    {
        while (keepGoing)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to your budgeting program!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Set Your Monthly Budget");
            Console.WriteLine("2. See Budget Status");
            Console.WriteLine("3. Add a Budget Category");
            Console.WriteLine("4. Remove a Budget Category");
            Console.WriteLine("5. Display Budget Categories");
            Console.WriteLine("6. Record a Transaction");
            Console.WriteLine("7. Load Budget");
            Console.WriteLine("8. Save Budget");
            Console.WriteLine("9. Reset Budget");
            Console.WriteLine("10. Quit");
            Console.Write("Enter a number from the above choices: ");
            _menuSelection = Console.ReadLine();
            bool isValidMenuSelection = IsInteger(_menuSelection, menuLength);
            // Continue loop until valid selection.
            if(isValidMenuSelection == true)
            {
                keepGoing = false;
            }
            else
            {
                keepGoing = true;
            }
        }
        return int.Parse(_menuSelection);
    }

    public int RecordTransactionMenu(int menuLength)
    {
        while (keepGoingTransactions)
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Record a Purchase");
            Console.WriteLine("2. Record a Credit or Refund");
            Console.WriteLine("3. Display Transactions");
            Console.Write("Enter a number from the above choices: ");
            _transactionMenuSelection = Console.ReadLine();
            bool isValidMenuSelection = IsInteger(_transactionMenuSelection, menuLength);
            // Continue loop until valid selection.
            if(isValidMenuSelection == true)
            {
                keepGoingTransactions = false;
            }
            else
            {
                keepGoingTransactions = true;
            }
        }
        return int.Parse(_transactionMenuSelection);
    }

    // Ensure string value is an integer.
    // Menu length is equal the menu length 1-i;
    public bool IsInteger(string menuSelection, int menuLength)
    {
        bool isInt = menuSelection.All(char.IsDigit);
        if (isInt == true)
        {
            _menuNumber = int.Parse(menuSelection);
            if (_menuNumber > 0 && _menuNumber < (menuLength + 1))
            {
                keepGoing = false;
                return true;
            }
            else
            {
                Console.WriteLine($"Please enter a value between 1 and {menuLength}");
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}