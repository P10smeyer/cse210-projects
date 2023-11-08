using System.ComponentModel;
using System.IO;
using System.Net.Mail;
using System.Text;


public class Journal
{
    // Stores list of entries created by the user. 
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry (Entry newEntry)
    {
        _entries.Add(newEntry);
        Console.WriteLine();
    }

    // Display all entries created up to this point.
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    // Saves all entries to a journal.txt file.
    public void SaveToFile()
    {
        Console.Write("What would you like to name your text file (exclude the file extension)? ");
        string filename = Console.ReadLine();
        Console.WriteLine($"Saving to {filename}.txt file...");

        using (StreamWriter outputFile = new StreamWriter($"{filename}.txt"))
        {
            // Add to text file with the WriteLine method
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date.ToShortDateString()}, {entry._promptText}, {entry._entryText}");
                Console.WriteLine();
            }
        }
    }
    public void LoadFromFile()
    {
        // Clear original _entries list. Was previously saved to file. Need to ensure there are not duplicates
        // added to the previous list. Will be loading and repopulaing list.
        _entries.Clear();

        Console.Write("What text file would you like to load (exclude the file extension)? ");
        string filename = Console.ReadLine();

        // Ensure a Journal.txt file exists before loading it.
        if (File.Exists($"{filename}.txt"))
        {
            Console.WriteLine($"Loading {filename}.txt...");
        
            // Read all lines from the text file.
            string[] lines = File.ReadAllLines($"{filename}.txt");

            foreach(string line in lines)
            {
                // For comma seprated values.
                string[] parts = line.Split(",");
                
                // parts[0] = Date
                // parts[1] = Prompt Text
                // parts[2] = Entry Text
                Entry entry = new Entry();
                entry._loadDate = parts[0];
                // Convert string to DateTime which is required for entry value.
                entry._date = DateTime.ParseExact(entry._loadDate, "M/d/yyyy", null);
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                AddEntry(entry);
                entry.Display();
            }
            Console.WriteLine();
        }
        // Advise the user to add an entry if there is not an entry to load.
        else
        {
            Console.WriteLine($"'{filename}.txt' does not yet exist. Try a different filename or select '1' to write your first journal entry.");
        }
    }
}