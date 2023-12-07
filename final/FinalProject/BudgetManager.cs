public class BudgetManager
{
    private double _amountRemaining;
    private double _amountSpent;
    
    List<string> _transactions;
    private MonthlyBudget _monthlyBudget = new MonthlyBudget(0, 0, 0);
     
    // User creates their budget for the month.
    public void CreateMonthlyBudget()
    {
        do
        {
            _monthlyBudget.CreateMonthlyBudget(_monthlyBudget);
        }
        while (_monthlyBudget.GetMonthlyBudget() <= 0);
        
    }

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
}