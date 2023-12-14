// Monthly budget which inherits from the 'Budget' class.
public class MonthlyBudget : Budget
{
    private double _totalAmountSpent; // Total amount spent in a monthly budget.
    private double _totalAmountRemaining; // Total amount remaining in a monthly budget.
    
    // Constructor for 'Monthly Budget.'
    public MonthlyBudget(double monthlyBudget, double totalAmountSpent, double totalAmountRemaining) : base(monthlyBudget)
    {
        _totalAmountSpent = totalAmountSpent;
        _totalAmountRemaining = totalAmountRemaining;
    }

    // User can create their monthly budget (must be positive and non-zero).
    public void CreateMonthlyBudget(MonthlyBudget monthlyBudget)
    {
        Console.Write("What will be your budget this month (excluding the '$' sign)? ");
        string selectedMonthlyBudget = Console.ReadLine();
        double number;
        // If the selectedMonthlyBudget is a double and non-zero the budget will be created.
        if (Double.TryParse(selectedMonthlyBudget, out number))
        {
            if (number > 0)
            {
                monthlyBudget.SetMonthlyBudget(number);
                Console.WriteLine($"Your monthly budget is set to ${Double.Round(number, 2)}");
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

    // Gets the total amount spent.
    public double GetTotalAmountSpent()
    {
        return _totalAmountSpent;
    }

    // Sets the total amount spent.
    public void SetTotalAmountSpent(double totalAmountSpent)
    {
        _totalAmountSpent = totalAmountSpent;
    }

    // Gets the total amount remaining.
    public double GetTotalAmountRemaining()
    {
        return _totalAmountRemaining;
    }

    // Sets the total amount remaining.
    public void SetTotalAmountRemaining(double totalAmountRemaining)
    {
        _totalAmountRemaining = totalAmountRemaining;
    }
}