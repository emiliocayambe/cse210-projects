using System;

/**
 * The Word class represents a single word within a scripture.
 * It tracks whether the word is currently visible or hidden.
 */
class Word
{
    // The actual text content of the word
    private string _text;
    
    // Boolean flag to track the visibility state of the word
    private bool _isHidden;

    /**
     * Constructor: Initializes a new word and sets its initial state to visible.
     * @param text - The string content of the word.
     */
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    /**
     * Returns the text to be displayed on the console.
     * If hidden, it returns a string of underscores of the same length as the text.
     */
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Returns underscores matching the length of the original word
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }

    /**
     * Updates the state of the word to hidden.
     */
    public void Hide()
    {
        _isHidden = true;
    }

    /**
     * Checks if the word is currently hidden.
     * @return True if the word is hidden, False otherwise.
     */
    public bool IsHidden()
    {
        return _isHidden;
    }
}