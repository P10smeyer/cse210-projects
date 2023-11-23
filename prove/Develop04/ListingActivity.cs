using System.Runtime.CompilerServices;

// Listing Activity Class which inherits from the Activity class.
public class ListingActivity : Activity
{
    private int _count; // Count for items listed in activity.
    private readonly List<string> _prompts;

    // Listing Activity constructor.
    public ListingActivity(string name, string description, int duration) : base(name, description, duration)
    {
        _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strenghts of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heros?"
        };
    }

    // Run the Listing Activity with the provided duration.
    public void Run(int duration)
    {
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine();
        // Get a random prompt.
        Random randomGenerator = new Random();
        int randomPrompt = randomGenerator.Next(_prompts.Count);
        Console.WriteLine($" --- {_prompts[randomPrompt]} ---");
        bool exitLoop = false;
        ShowCountDown(5, "You may begin in");
        // For timer.
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);
        do
        {
            // Keep looping through until the time has elapsed.
            if (DateTime.Now < futureTime)
            {
                Console.Write("> ");
                Console.ReadLine(); // If timer elapses on user's final entry program will end following that entry.
                _count++; // increment count of items for each iteration.
            }
            else
            {
                exitLoop = true;
            }
            
        }
        while (exitLoop == false);
        Console.WriteLine($"You listed {_count} items!");
    }
}