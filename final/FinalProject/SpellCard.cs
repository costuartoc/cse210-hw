public class SpellCard : Card
{
    private string _spellType;

    public SpellCard(string cardName, string cardEffect, string attribute, string spellType) : base(cardName, cardEffect, attribute)
    {
        _spellType = spellType;
    }

    public override void DisplayCardInfo()
    {
        Console.WriteLine($"Name: {_cardName} Attribute: {_attribute}");
        Console.WriteLine($"Effect: {_cardEffect}");
        Console.WriteLine($"Type: {_spellType}");
    }
    public override string GetCardRepresentation()
    {
        return $"SpellCard:|{_cardName}|{_cardEffect}|{_attribute}|{_spellType}";
    }
    
}
