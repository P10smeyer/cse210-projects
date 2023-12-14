// File Manager Class used for saving or loading a monthly budget including budget categories.
public class FileManager
{
    // For use when loading a budget from a .txt file. Returns the name of the file which will be saved.
    public string LoadBudget()
    {
        Console.Write("What would you like to name your text file (exclude the file extension)? ");
        string filename = Console.ReadLine();
        Console.WriteLine($"Loading {filename}.txt file...");
        return filename;
    }

    // For use when saving a budget to a .txt file format. Returns the name of the file which will be saved.
    public string SaveFile()
    {
        Console.Write("What would you like to name your text file (exclude the file extension)? ");
        string filename = Console.ReadLine();
        Console.WriteLine($"Saving to {filename}.txt file...");
        return filename;
    }

    // String representation for the monthly budget will be displayed in text file in the following format:
    // Monthly Budget, Total Amount Spent, Total Amount Remaining
    public string StringRepresentationMonthlyBudget(MonthlyBudget monthlyBudget)
    {
        return $"{monthlyBudget.GetMonthlyBudget()},{monthlyBudget.GetTotalAmountSpent()},{monthlyBudget.GetTotalAmountRemaining()}";
    }

    // String representation for budget categories will be displayed in text file in the following format:
    // Total Budget, Category Budget, Budget Category, Budget Spent In Category, Budget Remaining In Category
    public string StringRepresentationBudgetCategory(BudgetCategory budgetCategory)
    {
        return $"{budgetCategory.GetMonthlyBudget()},{budgetCategory.GetCategoryBudget()},{budgetCategory.GetBudgetCategory()},{budgetCategory.GetBudgetSpentInCategory()},{budgetCategory.GetBudgetRemainingInCategory()}";
    }

    // String representation for transactions will be displayed in text file in the following format:
    // Cost of Transaction, Sum of Transactions, Budget Category.
    public string StringRepresentationTransactions(Transactions transaction)
    {
        return $"{transaction.GetCostOfTransaction()},{transaction.GetSumOfTransactions()},{transaction.GetBudgetCategory()}";
    }
}