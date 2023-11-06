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
        Console.WriteLine("Saving to Journal.txt file...");
        string filename = "Journal.txt";

        using (StreamWriter outputFile = new StreamWriter(filename))
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

        // Ensure a Journal.txt file exists before loading it.
        if (File.Exists("Journal.txt"))
        {
            Console.WriteLine("Loading Journal.txt...");
            string filename = "Journal.txt";
        
            // Read all lines from the text file.
            string[] lines = File.ReadAllLines(filename);

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
            Console.WriteLine("'Journal.txt' does not yet exist. Select '1' to write your first journal entry.");
        }
    }
}