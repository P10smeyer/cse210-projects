using System;

// Main program. Allows user to complete one of three activities (breathing, reflecting, listing).
class Program
{
    static void Main(string[] args)
    {
        bool quit = false; // To determine when to quit.
        // Count the number of times each activity is run.
        int activityOneCount = 0;
        int activityTwoCount = 0;
        int activityThreeCount = 0;
        do
        {
            Console.WriteLine();
            // Create new instance for menu and three activities.
            Menu menu = new Menu("Menu Options: ", "1. Start breathing activity", "2. Start reflecting activity", "3. Start listing activity", "4. Quit");
            Activity activityOne = new Activity("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. " +
            "Clear your mind and focus on your breathing.", 0);
            Activity activityTwo = new Activity("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
            "This will help you recognize the power you have and how you can use it in other aspects of your life", 0);
            Activity activityThree = new Activity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things " +
            "as you can in a certain area.", 0);
            int rerun = 0; // Continue loop until rerun is non-zero.
            int menuNumber; // Selected menu option.
            do
            {
                menuNumber = menu.GetDisplayMenu();
                // Ensure menu selection is between 1 and 4.
                if (menuNumber > 0 && menuNumber < 5)
                {
                    rerun = menuNumber;
                }
                else
                {
                    Console.Clear(); // Clear console if loop is rerun and menu displays again.
                    Console.WriteLine("Please enter a value between 1 and 4.");
                }
            }
            while (rerun == 0);
            Console.Clear(); // Clear console before activity begins.
            // Breathing Activity
            if (menuNumber == 1)
            {
                activityOneCount++;
                activityOne.DisplayStartingMessage(activityOne.GetName(), activityOne.GetDescription());
                activityOne.DisplayEndingMessage();
                activityOne.ShowCountDown(5, "Get ready");
                BreathingActivity breathingActivity = new BreathingActivity("Breathing", 
                    "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 
                    activityOne.GetDuration());
                breathingActivity.Run(activityOne.GetDuration());
                activityOne.ActivityComplete(activityOne.GetName(), activityOne.GetDuration(), activityOneCount, activityTwoCount, activityThreeCount);
            }
            // Reflecting Activity
            else if  (menuNumber == 2)
            {
                activityTwoCount++;
                activityTwo.DisplayStartingMessage(activityTwo.GetName(), activityTwo.GetDescription());
                activityTwo.DisplayEndingMessage();
                activityTwo.ShowCountDown(5, "Get ready");
                ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
                    "This will help you recognize the power you have and how you can use it in other aspects of your life", activityTwo.GetDuration());
                reflectingActivity.Run(activityTwo.GetDuration());
                activityTwo.ActivityComplete(activityTwo.GetName(), activityTwo.GetDuration(), activityOneCount, activityTwoCount, activityThreeCount);
            }
            // Listing Activity.
            else if (menuNumber == 3)
            {
                activityThreeCount++;
                activityThree.DisplayStartingMessage(activityThree.GetName(), activityThree.GetDescription());
                activityThree.DisplayEndingMessage();
                activityThree.ShowCountDown(5, "Get ready");
                ListingActivity listingActivity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things " +
                    "as you can in a certain area.", activityThree.GetDuration());
                listingActivity.Run(activityThree.GetDuration());
                activityThree.ActivityComplete(activityThree.GetName(), activityThree.GetDuration(), activityOneCount, activityTwoCount, activityThreeCount);
            }
            // Quit doing activities and end the program.
            else if (menuNumber == 4)
            {
                quit = true;
            }
            // I don't expect this to occur. Program would end gracefully if this point was reached but will provide direction.
            else
            {
                Console.WriteLine("Error! Try rerunning the program.");
            }
        }
        while (quit == false);
    }
}