public class LinkCard : Card
{
    private string _attack;
    private string _linkRating;

    public LinkCard(string cardName, string cardEffect, string attribute, string attack, string linkRating) : base(cardName, cardEffect, attribute)
    {
        _attack = attack;
        _linkRating = linkRating;
    }

    public override void DisplayCardInfo()
    {
        Console.WriteLine($"Name: {_cardName} Attribute: {_attribute}");
        Console.WriteLine($"Effect: {_cardEffect}");
        Console.WriteLine($"Attack: {_attack} Link Rating: {_linkRating}");
    }
    public override string GetCardRepresentation()
    {
        return $"LinkCard:|{_cardName}|{_cardEffect}|{_attribute}|{_attack}|{_linkRating}";
    }
}