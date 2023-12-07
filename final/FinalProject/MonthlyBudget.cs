public class MonthlyBudget : Budget
{
    private double _totalAmountSpent;
    private double _totalAmountRemaining;
    

    public MonthlyBudget(double monthlyBudget, double totalAmountSpent, double totalAmountRemaining) : base(monthlyBudget)
    {
        _totalAmountSpent = totalAmountSpent;
        _totalAmountRemaining = totalAmountRemaining;
    }

    public void CreateMonthlyBudget(MonthlyBudget monthlyBudget)
    {
        Console.Write("What will be your budget this month (excluding the '$' sign)? ");
        string selectedMonthlyBudget = Console.ReadLine();
        double number;
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