using System;

/**
 * The Reference class handles the biblical location of the scripture.
 * It supports both single verses and verse ranges (e.g., Proverbs 3:5 or Proverbs 3:5-6).
 */
class Reference
{
    // The name of the book (e.g., "Proverbs")
    private string _book;
    
    // The chapter number
    private int _chapter;
    
    // The starting verse number
    private int _verse;
    
    // The ending verse number. Set to -1 if there is only a single verse.
    private int _endVerse;

    /**
     * Constructor: Initializes the reference with a book, chapter, and verse range.
     * @param book - The name of the book.
     * @param chapter - The chapter number.
     * @param verse - The starting verse.
     * @param endVerse - The ending verse (optional, defaults to -1).
     */
    public Reference(string book, int chapter, int verse, int endVerse = -1)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    /**
     * Formats and returns the scripture reference as a string.
     * If there is an end verse, it uses the format "Book Chapter:Start-End".
     * Otherwise, it uses the format "Book Chapter:Verse".
     */
    public string GetDisplayText()
    {
        if (_endVerse != -1)
        {
            // Format for multiple verses (e.g., Proverbs 3:5-6)
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        else
        {
            // Format for a single verse (e.g., Proverbs 3:5)
            return $"{_book} {_chapter}:{_verse}";
        }
    }
}