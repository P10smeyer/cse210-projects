class Scripture
{
    private Reference _reference = new Reference();
    private List<Word> _words = new List<Word>();

    // Constructor: Store each word in a text of scripture into a word list.
    public Scripture(Reference reference, string text)
    {   
        _reference = reference;
        string[] words = text.Split(' '); // Identify between words by using the space between.
        
        // Store each word in a word object.
        foreach (string singleWord in words)
        {
            Word word = new Word(singleWord);
            _words.Add(word);
        }
    }

    public List<Word> GetWordList()
    {
        return _words;
    }

    // Hide randome words from the text of scripture only.
    public void HideRandomWords(string text, List<Word> words, Reference reference, int referenceIndex, bool endVerse)
    {
        Random randomGenerator = new Random();
        int numberToHide = randomGenerator.Next(1, 4); // Hide one to three words in each verse.
        _reference = reference;
        int wordCount = words.Count; // Calculate the number of words in the scripture.
        int hiddenNumberCount = 0; // Counter for the number of words hidden. Will loop until "numberToHide" is reached.
        bool exitLoop = false; // To determine when to exit loop.
        do
        {
            Random hideOneWord = new Random();
            int indexToReplace = hideOneWord.Next(wordCount); // The index at which the word should be hidden ("__").
            // If word was not previously hidden hide the word, set to hidden, and display to console.
            if (words[indexToReplace].GetIsHidden() == false)
            {
                hiddenNumberCount++;
                Word hiddenWord = new Word(text);
                words[indexToReplace].SetText("___");
                words[indexToReplace].SetIsHidden(true);
                string displayText = GetDisplayText(_reference, referenceIndex, endVerse);
                hiddenWord.GetDisplayText(_words, displayText, endVerse);
                bool isCompletelyHidden = IsCompletelyHidden(_words);
                if (isCompletelyHidden == true || hiddenNumberCount == numberToHide)
                {
                    exitLoop = true;
                }
            }

        }
        while (exitLoop == false);   
    }

    // Get display text for scripture class.
    public string GetDisplayText(Reference reference, int referenceIndex, bool endVerse)
    {
        _reference = reference;
        if (endVerse == true)
        {
            return $"{_reference.GetBook(referenceIndex)} {_reference.GetChapter(referenceIndex)}: {_reference.GetVerse(referenceIndex)}-{_reference.GetEndVerse(referenceIndex)} ";
        }
        else
        {
            return $"{_reference.GetBook(referenceIndex)} {_reference.GetChapter(referenceIndex)}: {_reference.GetVerse(referenceIndex)} ";
        }
    }

    // If all of the word _text is hidden return true. Otherwise, return false.
    public bool IsCompletelyHidden(List<Word> words)
    {
        bool isCompletelyHidden = true;
        foreach (Word word in words)
        {
            if (word.GetIsHidden() != true)
            {
                isCompletelyHidden = false;
            }
        }
        return isCompletelyHidden;
    }
}