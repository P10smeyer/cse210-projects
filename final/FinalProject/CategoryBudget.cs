public class CategoryBudget : Budget
{
    private double _categoryBudget;
    private double _categoryBudgetSpent;
    private double _categoryBudgetRemaining;
    public CategoryBudget(double totalBudget, double categoryBudget, double categoryBudgetSpent, double categoryBudgetRemaining) : base(totalBudget)
    {
        _categoryBudget = categoryBudget;
        _categoryBudgetSpent = categoryBudgetSpent;
        _categoryBudgetRemaining = categoryBudgetRemaining;
    }
}