// This class generates a random journal prompt/topic that can be used for a journal entry.
public class PromptGenerator
{
    // String list of journal prompts.
    public List<string> _prompts = new List<string>
    {"Who was the most interesting person you interacted with today?", "What was the best part of your day?",
        "How did you see the hand of the Lord in my life today?", "What was the strongest emotion you felt today?",
        "If you had one thing I could do over today, what would it be?", "What is something new you learned today?", 
        "Share your testimony?", "What has strengthened your testimony?", "What was your favorite talk from last general conference and why?",
        "How can I become more like Jesus Christ?", "What is your favorite memory from you childhood?", 
        "What can you do to contribute more to your community?", "How have you benefited from serving?",
        "Share a time when you recognized a prompting from the Holy Ghost.", "If you could share one thing with your posterity what would it be?"
    };

    // Return a journal prompt from a list of _prompts.
    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int promptLength = _prompts.Count; // Get the number of journal prompts.
        int promptIndex = randomGenerator.Next(1, promptLength);
        return _prompts[promptIndex];
    }
}