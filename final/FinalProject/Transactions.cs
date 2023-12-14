// This class is for tracking transactions which can be applied to an established budget.
public class Transactions
{
    private double _costOfTransaction; // Individual cost of a transaction.
    private double _sumOfTransactions = 0; // Sum of all transactions for one category.
    private string _budgetCategory; // Description for type of transaction (e.g. food, movie, store, etc.)

    int _menuNumber; // Identifies valid user menu number selection.


    // Constructor for transactions.
    public Transactions(double costOfTransaction, double sumOfTransactions, string budgetCategory)
    {
        _costOfTransaction = costOfTransaction;
        _sumOfTransactions = sumOfTransactions;
        _budgetCategory = budgetCategory;
    }

    // Record a transaction which includes a purchase or a credit/refund.
    public Transactions RecordTransaction(List<BudgetCategory> budgetCategories, bool isPurchase)
    {
        Transactions transactions = new Transactions(0, 0, "");
        // If the enteredCost is a double and non-zero the purchase will be recorded.
        bool settingTransactionCost = true;
        while (settingTransactionCost)
        {
            Console.Write("How much was this transaction? ");
            string enteredCost = Console.ReadLine();
            // If the enteredCost is a double and non-zero the budget will be created.
            if (Double.TryParse(enteredCost, out _costOfTransaction))
            {
                if (_costOfTransaction > 0)
                {
                    Console.WriteLine($"Your purchase is set to ${Double.Round(_costOfTransaction, 2)}");
                    BudgetCategory tempBudgetCategory = new BudgetCategory(0, 0, "", 0, 0);
                    tempBudgetCategory.ListCategories(budgetCategories);
                    bool confirmingCategory = true;
                    while (confirmingCategory)
                    {
                        Console.Write("Which budget category does your transaction apply to (enter a number)? ");
                        _budgetCategory = Console.ReadLine();
                        bool isValidMenuSelection = IsInteger(_budgetCategory, budgetCategories.Count);
                        // Continue loop until valid selection.
                        if(isValidMenuSelection == true && int.Parse(_budgetCategory)> 0 && int.Parse(_budgetCategory) < (budgetCategories.Count + 1))
                        {
                            confirmingCategory = false;
                        }
                        else
                        {
                            Console.WriteLine("Please select a valid category.");
                            confirmingCategory = true;
                        } 
                    }
                    if (isPurchase)
                    {
                        transactions = new Transactions(_costOfTransaction, _sumOfTransactions, _budgetCategory);
                    }
                    // Is a refund or a credit. Transaction will have a negative value.
                    else if (isPurchase == false)
                    {
                        transactions = new Transactions(-_costOfTransaction, _sumOfTransactions, _budgetCategory);
                    }
                    SetSumOfTransactions();
                    SetMenuNumber();
                    settingTransactionCost = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid value (greater than '0').");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid value.");
            }     
        }
        return transactions;
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

    // Display Transactions.
    public void DisplayTransactions(List<Transactions> transactions, List<BudgetCategory> budgetCategories)
    {
        int i = 1;
        foreach(Transactions transaction in transactions)
        {   
            int index = int.Parse(transaction.GetBudgetCategory()) - 1;
            Console.WriteLine($"{i}. Amount: ${String.Format("{0:0.00}", transaction.GetCostOfTransaction())}, Budget Category: {budgetCategories[index].GetBudgetCategory()}");
            i++;
        }
    }

    // Gets the budget category.
    public string GetBudgetCategory()
    {
        return _budgetCategory;
    }

    // Gets the sume of transactions.
    public double GetSumOfTransactions()
    {
        return _sumOfTransactions;
    }

    // Gets the cost of a transaction.
    public double GetCostOfTransaction()
    {
        return _costOfTransaction;
    }

    // Gets the selected menu Number.
    public int GetMenuNumber(Transactions transactions)
    {
        return _menuNumber;
    }

    // Sets the menu number.
    public void SetMenuNumber()
    {
        _menuNumber = int.Parse(_budgetCategory);
    }
    
    // Returns the _sumOfTransactions which can be applied to a budget category.
    public void SetSumOfTransactions()
    {
        _sumOfTransactions += _costOfTransaction;
    }
}