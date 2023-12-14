using System.Globalization;

public class BudgetCategory : Budget
{
    private string _budgetCategory; // A category for the budget.
    private double _categoryBudget; // The chosen budget for the category.
    private double _budgetSpentInCategory; // The budget spent in a category.
    private double _budgetRemainingInCategory; // The budget remaining in a category.
    

    // Constructor for 'Budget Category.'
    public BudgetCategory(double totalBudget, double categoryBudget, string budgetCategory, double budgetSpentInCategory, double budgetRemainingInCategory) : base(totalBudget)
    {
        _budgetCategory = budgetCategory;
        _categoryBudget = categoryBudget;
        _budgetSpentInCategory = budgetSpentInCategory;
        _budgetRemainingInCategory = budgetRemainingInCategory;
    }

    // Add and returns a budget category.
    public BudgetCategory AddCategory(MonthlyBudget monthlyBudget)
    {
        BudgetCategory addBudgetCategory = new BudgetCategory(0, 0, "", 0, 0);
        bool settingCategory = true;
        string confirmCategory;
        while (settingCategory)
        {
            bool confirmingCategory = true;
            // Add a category.
            Console.Write("What category would you like to add within your budget? ");
            // For converting category to title case.
            TextInfo textInfo1 = new CultureInfo("en-US", false).TextInfo;
            _budgetCategory = Console.ReadLine();
            _budgetCategory = textInfo1.ToTitleCase(_budgetCategory);
            Console.Write($"Your selected category is: {_budgetCategory}. Is this correct (type 'y' or 'n')? ");
            confirmCategory = Console.ReadLine();
            while (confirmingCategory)
            {
                // If confirm category successful.
                if (confirmCategory.ToLower() == "yes" || confirmCategory.ToLower()  == "y")
                {
                    Console.WriteLine($"You have created the following category: {_budgetCategory}");
                    // Setting budget for the category.
                    bool settingCategoryBudget = true;
                    while (settingCategoryBudget)
                    {
                        Console.Write($"What will be your budget this month for the '{_budgetCategory}' category (excluding the '$' sign)? ");
                        string chosenCategoryBudget = Console.ReadLine();
                        // If the chosenCategoryBudget is a double and non-zero the budget will be created.
                        if (Double.TryParse(chosenCategoryBudget, out _categoryBudget))
                        {
                            if (_categoryBudget > 0)
                            {
                                _budgetSpentInCategory = 0;
                                _budgetRemainingInCategory = _categoryBudget;
                                addBudgetCategory = new BudgetCategory(monthlyBudget.GetMonthlyBudget(), _categoryBudget, _budgetCategory, _budgetSpentInCategory, _budgetRemainingInCategory);
                                Console.WriteLine($"Your monthly budget is set to ${Double.Round(_categoryBudget, 2)}");
                                confirmingCategory = false;
                                settingCategoryBudget = false;
                                settingCategory = false;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid monthly budget (greater than '0').");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid monthly budget.");
                        }     
                    }
                }
                else if (confirmCategory.ToLower()  == "no" || confirmCategory.ToLower()  == "n")
                {
                    confirmingCategory = false;
                    settingCategory = true;
                }
                else
                {
                    Console.Write("Please provide a 'y' or 'n' response: ");
                    confirmCategory = Console.ReadLine();
                    confirmingCategory = true;
                }
            }
        }
        return addBudgetCategory;
    }

    // Returns a category index to be removed.
    public int RemoveCategory(List<BudgetCategory> budgetCategories)
    {
        ListCategories(budgetCategories);
        Console.Write("Which category would you like to remove (enter a number)? ");
        string removeCategory = Console.ReadLine();
        bool keepGoing = true;
        while (keepGoing)
        {
            bool isInteger = IsInteger(removeCategory, budgetCategories.Count);
            if (isInteger == true)
            {
                keepGoing = false;
            }
            else
            {
                keepGoing = true;
                Console.Write($"Please enter a value greater than 0 and less than {budgetCategories.Count + 1}: ");
                removeCategory = Console.ReadLine();
            }
        }
        int removeCategoryIndex = int.Parse(removeCategory) - 1;
        return removeCategoryIndex;
    }

    // List all categories with budget and budget remaining.
    public void ListCategories(List<BudgetCategory> budgetCategories)
    {
        Console.WriteLine("Below are your categories:");
        if (budgetCategories.Count <= 0)
        {
            Console.WriteLine("You have not added any categories at this time. Select '3' from the main menu to add a category.");
        }
        int i = 1;
        foreach (BudgetCategory category in budgetCategories)
        {
            Console.WriteLine($"{i}. {category._budgetCategory}, Budget: ${String.Format("{0:0.00}", category._categoryBudget)}, Budget Remaining: ${String.Format("{0:0.00}", category._budgetRemainingInCategory)}");
            i++;
        }
    }

    // Ensure string value is an integer.
    // Menu length is equal the menu length 1-i;
    public bool IsInteger(string removeCategory, int menuLength)
    {
        bool isInt = removeCategory.All(char.IsDigit);
        int menuNumber;
        if (isInt == true)
        {
            menuNumber = int.Parse(removeCategory);
            if (menuNumber > 0 && menuNumber < (menuLength + 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    // public double AmountRemainingInCategory()
    // {
    //     double _budgetRemainingInCategory = _categoryBudget - _budgetSpentInCategory;
    //     return _budgetRemainingInCategory;
    // }

    // public void AmountSpentInCategory(List<Transactions> transactions)
    // {
        
    // }

    // Gets the budget category.
    public string GetBudgetCategory()
    {
        return _budgetCategory;
    }

    // Gets the category Budget.
    public double GetCategoryBudget()
    {
        return _categoryBudget;
    }

    // Gets the Budget Spent In Category.
    public double GetBudgetSpentInCategory()
    {
        return _budgetSpentInCategory;
    }

    // Gets the Budget Remaining In Category.
    public double GetBudgetRemainingInCategory()
    {
        return _budgetRemainingInCategory;
    }

    // Sets the category budget spent.
    public void SetBudgetSpent(double purchase)
    {
        _budgetSpentInCategory += purchase;
    }

    // Sets the budget remaining in a category.
    public void SetBudgetRemaining()
    {
        _budgetRemainingInCategory = _categoryBudget - _budgetSpentInCategory;
    }
}