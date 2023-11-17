class Word
{
    private string _text;
    private bool _isHidden;
    
    // Constructor. Sets default values for text and whether word has been hidden.
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return true;
    }

    // Get display text for the Word class.
    public void GetDisplayText(List<Word> words, string displayText, bool endVerse)
    {
        // if (endVerse == false)
        // {
            Console.Clear(); // Clear console before writing.
            Console.Write(displayText);
            foreach (Word word in words)
            {
                Console.Write(word._text + " ");
            }
        // }
        
        // If there is an endVerse we don't want to clear the console before displaying it.
        // if(endVerse == true)
        // {
        //     Console.WriteLine();
        //     Console.Write(displayText);
        //     foreach (Word word in words)
        //     {
        //         Console.Write(word._text + " ");
        //     }
        // }
        Console.WriteLine();
    }

    // Getters and Setters.
    public void SetText(string hiddenWord)
    {
        _text = hiddenWord;
    }

    public void SetIsHidden(bool isHidden)
    {
        _isHidden = isHidden;
    }

    public bool GetIsHidden()
    {
        return _isHidden;
    }
} 