// Budget base class.
public abstract class Budget
{
    private double _monthlyBudget;

    // Budget Constructor.
    // Parameters:
    // _monthlyBudget: Total budget for the month.
    public Budget(double monthlyBudget)
    {
        _monthlyBudget = monthlyBudget;
    }

    // Gets the monthly budget.
    public double GetMonthlyBudget()
    {
        return _monthlyBudget;
    }

    // Sets the monthly budget.
    public void SetMonthlyBudget(double monthlyBudget)
    {
        _monthlyBudget = monthlyBudget;
    }
}