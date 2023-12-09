public class BudgetManager
{
    private double _amountRemaining;
    private double _amountSpent;
    
    List<Transactions> _transactions = new List<Transactions>();
    private MonthlyBudget _monthlyBudget = new MonthlyBudget(0, 0, 0);
    private List<BudgetCategory> _budgetCategories = new List<BudgetCategory>();
     
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

    public void DisplayBudgetCategories()
    {
        BudgetCategory budgetCategory = new BudgetCategory(_monthlyBudget.GetMonthlyBudget(), 0, "", 0, 0);
        budgetCategory.ListCategories(_budgetCategories);
    }

    public void Transactions(int transactionMenuSelection)
    {
        Transactions transactions = new Transactions(0, 0, "");
        // If recording a purchase.
        if (transactionMenuSelection == 1)
        {
            transactions = transactions.RecordPurchase(_budgetCategories);
            _transactions.Add(transactions);
            int index = int.Parse(transactions.GetBudgetCategory()) - 1;
            _budgetCategories[index].SetBudgetSpent(transactions.GetCostOfTransaction());
            _budgetCategories[index].SetBudgetRemaining();
        }
    }
}