using System;

// This program displays a full scripture and then hides a few words at a time until the complete scripture is hidden.
class Program
{
    static void Main(string[] args)
    {
        string userEntry; // tracks user entries in the console.
        bool keepGoing = true; // For determining when to break out of loop.
        bool isCompletelyHidden = false; // Determine if the words are completely hidden.
        bool endVerse = false; // Determines if there is an endVerse to account for in displaying.
        string text;
        Console.WriteLine();
        Reference reference = new Reference();
        int referenceIndex = reference.GetRandomIndex(); 
        if (referenceIndex == 2)
        {
            endVerse = true;
        }
        Scripture scripture;
        List<Word> words;
        if (endVerse == false)
        {
            text = reference.GetStartReference(referenceIndex);
            scripture = new Scripture(reference, text);
        }
        else
        {
            text = reference.GetStartReference(referenceIndex) + " " + reference.GetEndReference();
            scripture = new Scripture(reference, text);
        }
        words = scripture.GetWordList();
        Console.WriteLine(reference.GetDisplayText(referenceIndex));
        do
        {
            // user entry
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            userEntry = Console.ReadLine();
            // Exit program if the user types quit or all of the words are completely hidden.
            if (userEntry == "quit" || isCompletelyHidden == true)
            {
                keepGoing = false;
            }
            // Hide random words and periodically checks if words are all hidden.
            else
            {
                scripture.HideRandomWords(text, words, reference, referenceIndex, endVerse);
                isCompletelyHidden = scripture.IsCompletelyHidden(words);
            }
        }
        while (keepGoing == true);
    }
}