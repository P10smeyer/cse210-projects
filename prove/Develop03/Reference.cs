class Reference
{
    private List<string> _book = new List<string>()
    {
        "1 Nephi", "2 Nephi", "Alma"
    };
    private List<int> _chapter = new List<int>()
    {
        3, 2, 37
    };
    private List<int> _verse = new List<int>()
    {
        7, 25, 6
    };

    // Will need to use _endReference if int is a non-zero number.
    private List<int> _endVerse = new List<int>()
    {
        0, 0, 7
    };

    private List<string> _startReference = new List<string>()
    {
        "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.",
        "Adam fell that men might be; and men are, that they might have joy.",
        "Now ye may suppose that this is foolishness in me; but behold I say unto you, that by small and simple things are great things brought to pass; and small means in many instances doth confound the wise.",
    };

    private string _endReference = "And the Lord God doth work by means to bring about his great and eternal purposes; and by very small means the Lord doth confound the wise and bringeth about the salvation of many souls.";

    // Get Display Text for the Reference class.
    public string GetDisplayText(int referenceIndex)
    {   
        // Will grab a random index for the verse to try memorizing. If loop: for case where there is no end verse/reference.
        // Else: If there is end verse and reference applicable.
        if (_endVerse[referenceIndex] == 0)
        {
            return $"{_book[referenceIndex]} {_chapter[referenceIndex]}: {_verse[referenceIndex]} {_startReference[referenceIndex]}";
        }
        else
        {
            return $"{_book[referenceIndex]} {_chapter[referenceIndex]}: {_verse[referenceIndex]}-{_endVerse[referenceIndex]} {_startReference[referenceIndex]} {_endReference}";
        }     
    }

    // Get a random index which will identify book, chapter, verse/text which should be used).
    public int GetRandomIndex()
    {
        Random randomGenerator = new Random();
        int referenceLength = _startReference.Count; // Get the number of references or scriptures to randomly choose from.
        int referenceIndex = randomGenerator.Next(0, referenceLength);
        return referenceIndex;
    }
    
    // Below contains all getters of member variables.
    public string GetBook(int randomReference)
    {
        return _book[randomReference];
    }

    public int GetChapter(int randomReference)
    {
        return _chapter[randomReference];
    }

     public int GetVerse(int randomReference)
    {
        return _verse[randomReference];
    }

    public int GetEndVerse(int randomReference)
    {
        return _endVerse[randomReference];
    }

    public string GetStartReference(int randomReference)
    {
        return _startReference[randomReference];
    }

    public string GetEndReference()
    {
        return _endReference;
    }
}