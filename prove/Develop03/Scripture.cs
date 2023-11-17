using System.Runtime.InteropServices.Marshalling;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    
    
    public Scripture(Reference reference, string scripture)
    {
        List<string> wordList = scripture.Split(" ").ToList();
        foreach (string word in wordList)
        {
            Word word1 = new Word(word);
            _words.Add(word1);
        }
        _reference = reference;
    }
    public void HideRandomWords(int numberToHide)
    {
        int stop = 0;
        while (stop != numberToHide)
        {    
            bool isCompletelyHidden = IsCompletelyHidden();
            
            Random _rnd = new Random();
            int index = _rnd.Next(_words.Count);

            if(isCompletelyHidden == true)
            {
                stop = numberToHide;
            }
            else if (_words[index].IsHidden() != true)
            {
                _words[index].Hide();
                stop = stop+1;
            }
            
        }
    }
    public string GetDisplayText()
    {
        List<string> justTheText = new List<string>();
        foreach (Word word in _words)
        {
            string newWord = word.GetDisplayText();
            justTheText.Add(newWord);
        }
        string scripture = string.Join(" ", justTheText);
        
        string referenceText = _reference.GetDisplayText();
        string fullScripture = $"{referenceText} {scripture}";

        return fullScripture;
    }
    public bool IsCompletelyHidden()
    {
        int completelyHidden = 0;
        foreach (Word word in _words)
        {
            bool check = word.IsHidden();
            
            if(check == true)
            {
                completelyHidden = completelyHidden + 1;
            }
        }

        if(completelyHidden == _words.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}