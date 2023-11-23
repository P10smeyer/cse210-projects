// Base activity class.
public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    // Constructor for Activity Class.
    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    // The initial display prior to starting any activity such as the breathing, reflection, or listing activity.
    public void DisplayStartingMessage(string name, string description)
    {
        Console.WriteLine();
        Console.WriteLine($"Welcome to the {name} activity.");
        Console.WriteLine();
        Console.WriteLine(description);
        Console.WriteLine();
    }

    // The ending display prior to starting any activity such as the breathing, reflection, or listing activity.
    public void DisplayEndingMessage()
    {
        bool isInt = false;
        do
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string durationInSeconds = Console.ReadLine();
            isInt = IsInt(durationInSeconds);
            if (isInt == false)
            {
                Console.WriteLine("Please enter an integer (non-decimal) value.");
            }
            else
            {
                _duration = int.Parse(durationInSeconds); // Store duration in activity instance/object.
            }
        }
        while (isInt == false); 
    }

    // Will return true if string is an integer and false otherwise.
    public bool IsInt(string userEntry)
    {
        bool isInt = userEntry.All(char.IsDigit);
        if (isInt == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // This is primarily the Get Ready countdown at the beginning of any activity.
    // Can also, be used for other purposes.
    public void ShowCountDown(int seconds, string prompt)
    {
        // Clear prior screen if beginning the activity.
        if (prompt == "Get ready")
        {
            Console.Clear();
        }
        Console.Write($"{prompt}...");
        for(int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    // Output to console when the activity is completed.
    public void ActivityComplete(string name, int duration, int activityOneCount, int activityTwoCount, int activityThreeCount)
    {
        Console.WriteLine();
        Console.WriteLine("Well Done!!");
        Console.WriteLine();
        Console.WriteLine($"You have completed another {duration} seconds of the {name} Activity.");
        Console.WriteLine();
        Console.WriteLine("Number of times completed:");
        Console.WriteLine($"Breathing Activity: {activityOneCount}");
        Console.WriteLine($"Reflecting Activity: {activityTwoCount}");
        Console.WriteLine($"Listing Activity: {activityThreeCount}");
    }

    // Getter for _name.
    public string GetName()
    {
        return _name;
    }

    // Getter for _description.
    public string GetDescription()
    {
        return _description;
    }

    // Getter for _duration.
    public int GetDuration()
    {
        return _duration;
    }
}