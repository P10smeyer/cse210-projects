public class BudgetManager
{
    private double _amountRemaining; // Amount remaining in total budget.
    private double _amountSpent; // Amount spent in total budget.
    
    private List<Transactions> _transactions = new List<Transactions>(); // Stores a list of transactions.
    private MonthlyBudget _monthlyBudget = new MonthlyBudget(0, 0, 0); // Instance of a monthly budget.
    private List<BudgetCategory> _budgetCategories = new List<BudgetCategory>(); // Stores a list of budget categories.

    private string _filename; // Filename for loading or saving a file.
     
    // User creates their budget for the month.
    public void CreateMonthlyBudget()
    {
        do
        {
            _monthlyBudget.CreateMonthlyBudget(_monthlyBudget);
        }
        while (_monthlyBudget.GetMonthlyBudget() <= 0);
        
    }

    // User can obtain status on their set monthly budget, total amount spent, and total amount remaining. If the user has not 
    // yet set a budget greater than '0' they will be instructed to before budget status can be displayed.
    public void BudgetStatus()
    {
        if(_monthlyBudget.GetMonthlyBudget() <= 0)
        {
            Console.WriteLine($"Your monthly budget is currently ${_monthlyBudget.GetMonthlyBudget()}. Please select '1' to set a monthly budget greater than 0.");
        }
        else
        {
            Console.WriteLine($"Your monthly budget is ${_monthlyBudget.GetMonthlyBudget()}");
            Console.WriteLine($"You have spent ${_monthlyBudget.GetTotalAmountSpent()}");
            Console.WriteLine($"You have ${_monthlyBudget.GetTotalAmountRemaining()} remaining");
        }
    }

    // User can add a sub-budget for a category (e.g. groceries, insurance, internet, etc.).
    public void AddBudgetCategory()
    {
        BudgetCategory budgetCategory = new BudgetCategory(_monthlyBudget.GetMonthlyBudget(), 0, "", 0, 0);
        budgetCategory = budgetCategory.AddCategory(_monthlyBudget);
        _budgetCategories.Add(budgetCategory);
    }

    // User can remove a sub-budget for a category (e.g. groceries, insurance, internet, etc.).
    public void RemoveBudgetCategory()
    {
        BudgetCategory budgetCategory = new BudgetCategory(_monthlyBudget.GetMonthlyBudget(), 0, "", 0, 0);
        int removeCategoryIndex = budgetCategory.RemoveCategory(_budgetCategories);
        _budgetCategories.Remove(_budgetCategories[removeCategoryIndex]);
    }

    // Displays Budget categories.
    public void DisplayBudgetCategories()
    {
        BudgetCategory budgetCategory = new BudgetCategory(_monthlyBudget.GetMonthlyBudget(), 0, "", 0, 0);
        budgetCategory.ListCategories(_budgetCategories);
    }

    // Handles all transactions. User selects from 3 menu choices. Can either record a purchase, record a credit/refund, or display transactions.
    public void Transactions(int transactionMenuSelection)
    {
        Transactions transactions = new Transactions(0, 0, "");
        // If recording a purchase or a credit/refund.
        if (transactionMenuSelection == 1 || transactionMenuSelection == 2)
        {
            if (transactionMenuSelection == 1)
            {
                transactions = transactions.RecordTransaction(_budgetCategories, true);
            }
            else if (transactionMenuSelection == 2)
            {
                transactions = transactions.RecordTransaction(_budgetCategories, false);
            }
            _transactions.Add(transactions);
            int index = int.Parse(transactions.GetBudgetCategory()) - 1;
            _budgetCategories[index].SetBudgetSpent(transactions.GetCostOfTransaction());
            _budgetCategories[index].SetBudgetRemaining();
            _amountSpent += transactions.GetCostOfTransaction();
            _amountRemaining = _monthlyBudget.GetMonthlyBudget() - _amountSpent;
            _monthlyBudget.SetTotalAmountRemaining(_amountRemaining);
            _monthlyBudget.SetTotalAmountSpent(_amountSpent);
        }
        else if (transactionMenuSelection == 3)
        {
            transactions.DisplayTransactions(_transactions, _budgetCategories);
        }
    }

    // Load the Monthly Budget to a .txt File. The first line will contain the MonthlyBudget with each parameter separated by a comma.
    // The remaining lines will contain transactions or Budget Category as applicable.
    public void LoadMonthlyBudget()
    {
        // Clear all fields to ensure old data is not introduced.
        ResetBudget();

        FileManager fileManager = new FileManager();
        _filename = fileManager.LoadBudget();

        // Ensure a file exists before loading it.
        if (File.Exists($"{_filename}.txt"))
        {
            Console.WriteLine($"Loading {_filename}.txt...");

            // Read all lines from the text file.
            string[] lines = File.ReadAllLines($"{_filename}.txt");

            // If a Monthly Budget
            // parts[0] = Monthly Budget
            // parts[1] = Total Amount Spent
            // parts[2] = Total Amount Remaining
            // If a Budget Category
            // parts[0] = Total Budget
            // parts[1] = Category Budget
            // parts[2] = Budget Category
            // parts[3] = Budget Spent in Category
            // parts[4] = Budget Remaining in Category
            // If a Transaction
            // parts[0] = Cost of Transaction
            // parts[1] = Sum of Transactions
            // parts[2] = Budget Category
            int i = 0;
            foreach(string line in lines)
            {
                // For first line it will be a monthly budget.
                string[] parts = line.Split(",");

                if (parts.Length > 3)
                {
                    BudgetCategory budgetCategory = new BudgetCategory(double.Parse(parts[0]), double.Parse(parts[1]), parts[2], double.Parse(parts[3]), double.Parse(parts[4]));
                    _budgetCategories.Add(budgetCategory);
                }
                if (parts.Length == 3)
                {
                    if (i == 0)
                    {
                        _monthlyBudget = new MonthlyBudget(double.Parse(parts[0]), double.Parse(parts[1]), double.Parse(parts[2]));
                        i++;
                    }
                    else
                    {
                        Transactions transaction = new Transactions(double.Parse(parts[0]), double.Parse(parts[1]), parts[2]);
                        _transactions.Add(transaction); 
                    } 
                }  
            }  
        }
        Console.WriteLine($"Your {_filename}.txt file has been loaded!");
    }

    // Save the Monthly Budget to a .txt File. The first line will contain the MonthlyBudget with each parameter separated by a comma.
    // The remaining lines will contain transactions or Budget Category as applicable.
    public void SaveMonthlyBudget()
    {
        FileManager fileManager = new FileManager();
        _filename = fileManager.SaveFile();
        string stringRepresentationBudget = fileManager.StringRepresentationMonthlyBudget(_monthlyBudget);

        using (StreamWriter outputFile = new StreamWriter($"{_filename}.txt"))
        {
            // Add to text file with the WriteLine method
            outputFile.WriteLine(stringRepresentationBudget);
            if (_transactions.Count > 0)
            {
                foreach (Transactions transaction in _transactions)
                {
                    string stringRepresentationTransactions = fileManager.StringRepresentationTransactions(transaction);
                    outputFile.WriteLine(stringRepresentationTransactions);
                }
            }
            if (_budgetCategories.Count > 0)
            {
                foreach (BudgetCategory budgetCategory in _budgetCategories)
                {
                    string stringRepresentationCategories = fileManager.StringRepresentationBudgetCategory(budgetCategory);
                    outputFile.WriteLine(stringRepresentationCategories);
                }
            }
            Console.WriteLine($"Your {_filename}.txt file has been saved!");
        }
    }

    // Reset the budget by clearning fields.
    public void ResetBudget()
    {
        _transactions.Clear();
        _budgetCategories.Clear();
        _amountRemaining = 0;
        _amountSpent = 0;
        _filename = "";
        _monthlyBudget = new MonthlyBudget(0, 0, 0);
    }
}