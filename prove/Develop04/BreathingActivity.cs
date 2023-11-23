// Breathing Activity Class which inherits from the Activity class.
public class BreathingActivity : Activity
{
    // Breathing Activity constructor.
    public BreathingActivity(string name, string description, int duration) : base(name, description, duration)
    {
        
    }

    // Run the Breathing Activity with the provided duration. Note: Time will extend beyond selected duration
    // if the duration is reached during the breathe-in/breathe-out process. At that point the program will 
    // terminate after the breathe out.
    public void Run(int duration)
    {
        // For timer.
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);

        // Keep looping through until the time has elapsed.
        for (int i = 1; i < duration; i++)
        {
            if (DateTime.Now < futureTime)
            {
                // Don't want them releasing their breath for more than 6 seconds.
                // Don't want someone passing out.
                if (i == 3)
                {
                    i = 1;
                }
                Console.WriteLine();
                // Set to have breathe in half as long as breath out starting at 1.
                ShowCountDown(i, "Breathe in");
                ShowCountDown(i*2, "Breathe out");
            }
            else 
            {
                // If time has elapsed break on next iteration.
                i = duration;
                break;
            }
        }
    }     
}