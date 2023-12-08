public abstract class Card
{
    protected string _cardName;
    protected string _cardEffect;
    protected string _attribute;

    public Card (string cardName, string cardEffect, string attribute)
    {
        _cardName = cardName;
        _cardEffect = cardEffect;
        _attribute = attribute;
    }

    public string GetCardName()
    {
        return _cardName;
    }
    public string GetAttribute()
    {
        return _attribute;
    }

    public abstract void DisplayCardInfo();
    public abstract string GetCardRepresentation();
    
}