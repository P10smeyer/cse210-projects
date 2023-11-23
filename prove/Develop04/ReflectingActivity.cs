// Reflecting Activity Class which inherits from the Activity class.
public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    
    private readonly List<string> _questions;

    // Reflecting Activity constructor.
    public ReflectingActivity(string name, string description, int duration) : base(name, description, duration)
    {
        _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    // Run the Reflecting Activity with the provided duration.
    public void Run(int duration)
    {
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        // Get a random prompt.
        Random randomGenerator = new Random();
        int randomPrompt = randomGenerator.Next(_prompts.Count);
        Console.WriteLine($" --- {_prompts[randomPrompt]} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        ShowCountDown(5, "You may begin in");
        Console.Clear();
        Random randomGeneratorTwo = new Random();
        // Randomizes the list prior to displaying the string. Since foreach is used
        // each question will only be used once.
        var randomQuestionList = _questions.OrderBy(item => randomGeneratorTwo.Next());
        // Keep looping through until the time has elapsed.
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);
        for (int i = 0; i < duration; i++)
        {
            foreach (string question in randomQuestionList)
            {
                if (DateTime.Now < futureTime)
                {
                    Console.WriteLine();
                    ShowCountDown(5, $"> {question}");
                }
                else
                {
                    break;
                }
            }
        }
    }
}