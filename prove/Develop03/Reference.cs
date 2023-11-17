public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private string _endVerse;
    
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = $"-{endVerse}";
    }
    public string GetDisplayText()
    {
        string _scriptureReference = $"{_book} {_chapter}:{_verse}{_endVerse}";
        return _scriptureReference;
    }
}