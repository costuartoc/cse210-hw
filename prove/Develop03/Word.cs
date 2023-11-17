public class Word
{
    private string _text;

    private bool _isHidden;

    public Word(string word)
    {
        _text = word;
        _isHidden = false;
    }
    public void Hide()
    {
        _text = new String('_' , _text.Length);
        _isHidden = true;
    }
    public void Show()
    {
        Console.Write($"{_text}");
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()
    {
        return _text;
    }
}