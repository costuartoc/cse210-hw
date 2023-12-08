public class TrapCard : Card
{
    private string _trapType;

    public TrapCard(string cardName, string cardEffect, string attribute, string trapType) : base(cardName, cardEffect, attribute)
    {
        _trapType = trapType;
    }

    public override void DisplayCardInfo()
    {
        Console.WriteLine($"Name: {_cardName} Attribute: {_attribute}");
        Console.WriteLine($"Effect: {_cardEffect}");
        Console.WriteLine($"Type: {_trapType}");
    }
    public override string GetCardRepresentation()
    {
        return $"TrapCard:|{_cardName}|{_cardEffect}|{_attribute}|{_trapType}";
    }
}