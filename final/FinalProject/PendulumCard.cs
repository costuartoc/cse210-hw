public class PendulumCard : Card
{
    private string _attack;
    private string _defense;
    private string _pendulumEffect;

    public PendulumCard(string cardName, string cardEffect, string attribute, string attack, string defense, string pendulumEffect) : base(cardName, cardEffect, attribute)
    {
        _attack = attack;
        _defense = defense;
        _pendulumEffect = pendulumEffect;
    }

    public override void DisplayCardInfo()
    {
        Console.WriteLine($"Name: {_cardName} Attribute: {_attribute}");
        Console.WriteLine($"Pendulum Effect: {_pendulumEffect}");
        Console.WriteLine($"Effect: {_cardEffect}");
        Console.WriteLine($"Attack: {_attack} Defense: {_defense}");
    }
    public override string GetCardRepresentation()
    {
        return $"PendulumCard:|{_cardName}|{_cardEffect}|{_attribute}|{_attack}|{_defense}|{_pendulumEffect}";
    }
}