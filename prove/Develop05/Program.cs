using System;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        bool quit = false; // To determine when to quit.
        GoalManager goalManager = new GoalManager(0, "Menu Options: ", "1. Create New Goal", 
                "2. List Goals", "3. Save Goals", "4. Load Goals", "5. Record Event", "6. Quit");
        do
        {
            int rerun = 0; // Continue loop until rerun is non-zero.
            int menuNumber; // Selected menu option.
            do
            {
                menuNumber = goalManager.Start(goalManager.GetScore());
                // Ensure menu selection is between 1 and 6.
                if (menuNumber > 0 && menuNumber < 7)
                {
                    rerun = menuNumber;
                }
                else
                {
                    Console.Clear(); // Clear console if loop is rerun and menu displays again.
                    Console.WriteLine("Please enter a value between 1 and 6.");
                }
            }
            while (rerun == 0);
            
            // If '1' is selected to 'Create New Goal.'
            if (menuNumber == 1)
            {
                goals = goalManager.CreateNewGoal(3);
            }
            // If '2' is selected to 'List Goals.'
            else if (menuNumber == 2)
            {
                goalManager.SetGoals(goals);
                goalManager.ListGoalDetails(goalManager.GetScore());
            }
            // If '3' is selected to 'Save Goals.'
            else if (menuNumber == 3)
            {
                goalManager.SetGoals(goals);
                goalManager.SaveGoals(goals);
            }
            // If '5' is selected to 'Record Event.'
            else if (menuNumber == 5)
            {
                goalManager.SetGoals(goals);
                goalManager.RecordEvent(goals);
                // int goalAccomplishedIndex = goalManager.DisplayGoalNames();

            }
        }
        while (quit == false);
    }
}