public class MonsterCard : Card
{
    private string _attack;
    private string _defense;

    public MonsterCard(string cardName, string cardEffect, string attribute, string attack, string defense) : base(cardName, cardEffect, attribute)
    {
        _attack = attack;
        _defense = defense;
    }

    public override void DisplayCardInfo()
    {
        Console.WriteLine($"Name: {_cardName} Attribute: {_attribute}");
        Console.WriteLine($"Effect: {_cardEffect}");
        Console.WriteLine($"Attack: {_attack} Defense: {_defense}");
    }
    public override string GetCardRepresentation()
    {
        return $"MonsterCard:|{_cardName}|{_cardEffect}|{_attribute}|{_attack}|{_defense}";
    }
}