public class Deck
{
    private string _deckName;
    private List<Card> _deck = new List<Card>();

    public Deck(string deckName)
    {
        _deckName = deckName;
    }
    public string DisplayDeckName()
    {
        return _deckName;
    }
    public void AddCardToDeck(int cardNumber, List<Card> list)
    {
        _deck.Add(list[cardNumber]);
    }
    public void DisplayCardsInDeck()
    {
        Console.WriteLine($"All cards in your {_deckName} deck: ");
        int number = 0;
        
        foreach (Card c in _deck)
        {
            number = number + 1;
            Console.WriteLine($" {number}. {c.GetCardName()}");
        }
    }
    public void SaveDeck(string file)
    {
        string fileName = file;
        
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine($"{_deckName}");
            foreach (Card c in _deck)
            {
                outputFile.WriteLine($"{c.GetCardRepresentation()}");
            }
        }
    }
    public void LoadDeck(string file)
    {
        string fileName = $"{file}.txt";
        if (File.Exists($"C:/Users/costu/OneDrive/Desktop/Programming/cse210-hw/final/FinalProject/{fileName}"))    
        {    

            string[] lines = System.IO.File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");

                if (parts[0] == "MonsterCard:")
                {
                    MonsterCard newMonsterCard = new MonsterCard(parts[1],parts[2],parts[3],parts[4],parts[5]);
                    _deck.Add(newMonsterCard);
                }
                else if (parts[0] == "PendulumCard:")
                {
                    PendulumCard newPendulumCard = new PendulumCard(parts[1],parts[2],parts[3],parts[4],parts[5],parts[5]);
                    _deck.Add(newPendulumCard);
                }
                else if (parts[0] == "LinkCard:")
                {
                    LinkCard newLinkCard = new LinkCard(parts[1],parts[2],parts[3],parts[4],parts[5]);
                    _deck.Add(newLinkCard);
                }
                else if (parts[0] == "SpellCard:")
                {
                    SpellCard newSpellCard = new SpellCard(parts[1],parts[2],parts[3],parts[4]);
                    _deck.Add(newSpellCard);
                }
                else if (parts[0] == "TrapCard:")
                {
                    TrapCard newTrapCard = new TrapCard(parts[1],parts[2],parts[3],parts[4]);
                    _deck.Add(newTrapCard);
                }
                else
                {
                    _deckName = parts[0];
                }
            }
        }
        else
        {
            Console.Write("Couldn't find a file by that name.");
            Console.ReadLine();
        }
    }
}

