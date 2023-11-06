// Display Entry which includes date, prompt/topic, and user journal entry.
public class Entry
{
    public DateTime _date;
    public string _loadDate;
    public string _promptText;
    public string _entryText;
    
    public void Display()
    {
        Console.WriteLine($"{_date.ToShortDateString()}, {_promptText}, {_entryText}");
    }
}