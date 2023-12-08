using System.Net;

public class CardManager
{
    private List<Card> _cards = new List<Card>();

    private List<Deck> _decks = new List<Deck>();

    public CardManager()
    {

    }
    public void Run()
    {
        Console.WriteLine("Welcome to the Yu-Gi-Oh! deck builder!");
        Console.WriteLine("Press enter to continue:");
        Console.ReadLine();

        string condition = " ";

        while (condition != "7")
        {
            Console.Clear();
            Console.WriteLine("Menu Options: ");
            Console.WriteLine(" 1. Add a Card");
            Console.WriteLine(" 2. Make a Deck");
            Console.WriteLine(" 3. View Cards");
            Console.WriteLine(" 4. View Decks");
            Console.WriteLine(" 5. Load Cards");
            Console.WriteLine(" 6. Load Decks");
            Console.WriteLine(" 7. Quit");
            Console.Write("Select a choice from the menu: ");
            condition = Console.ReadLine();

            if (condition == "1")
            {
                AddCard();
            }
            else if (condition == "3")
            {
                Console.Clear();
                ListCardsByType();
                Console.Write("Press enter to return to the main menu: ");
                Console.ReadLine();
            }
            else if (condition == "4")
            {
                Console.Clear();
                ListDecks();
                Console.Write("If you would like to view the contents of a deck enter the number next to it in the list(otherwise enter no): ");
                string userInput = Console.ReadLine().ToLower();
                
                int tryParseResult;

                if (_decks.Count() == 0)
                {
                    Console.WriteLine("There are no decks listed at the moment.");
                    Console.Write("Press enter to return to the main menu: ");
                    Console.ReadLine();
                }
                else if (int.TryParse(userInput, out tryParseResult))
                {
                    int userInputInt = tryParseResult;

                    _decks[userInputInt - 1].DisplayCardsInDeck();
                    Console.Write("Press enter to return to the main menu: ");
                    Console.ReadLine();
                    
                }
                else
                {
                    Console.Write("Press enter to return to the main menu: ");
                    Console.ReadLine();
                }
            }
            else if (condition == "2")
            {
                Console.Clear();
                CreateDeck();
                Console.Write("Press enter to return to the main menu: ");
                Console.ReadLine();
            }
            else if (condition == "5")
            {
                Console.Write("What is the filename of the card file? ");
                string fileName = Console.ReadLine();
                LoadCards(fileName);
            }
            else if (condition == "6")
            {
                Console.Write("What is the filename of the deck file? ");
                string fileName = Console.ReadLine();
                Deck newDeck = new Deck(fileName);
                newDeck.LoadDeck(fileName);
                _decks.Add(newDeck);
            }
        }

    }
    public void AddCard()
    {
        Console.Clear();
        Console.WriteLine("What type of card would you like to add?: ");
        Console.WriteLine(" 1. Monster Card");
        Console.WriteLine(" 2. Pendulum Card");
        Console.WriteLine(" 3. Link Card");
        Console.WriteLine(" 4. Spell Card");
        Console.WriteLine(" 5. Trap Card");
        Console.WriteLine(" 6. Return to the main Menu");
        Console.Write("Select a choice from the menu: ");
        string cardType = Console.ReadLine();

        if (cardType == "1")
        {
            Console.Write("What is the name of the card? ");
            string name = Console.ReadLine();
            Console.Write("What is the card's effect text? ");
            string effect = Console.ReadLine();
            Console.Write("What is the card's attribute? ");
            string attribute = Console.ReadLine();
            Console.Write("What is the card's attack value? ");
            string attack = Console.ReadLine();
            Console.Write("What is the card's defense value? ");
            string defense = Console.ReadLine();

            MonsterCard monsterCard = new MonsterCard(name, effect, attribute, attack, defense);

            _cards.Add(monsterCard);

        }
        else if (cardType == "2")
        {
            Console.Write("What is the name of the card? ");
            string name = Console.ReadLine();
            Console.Write("What is the card's effect text? ");
            string effect = Console.ReadLine();
            Console.Write("What is the card's attribute? ");
            string attribute = Console.ReadLine();
            Console.Write("What is the card's attack value? ");
            string attack = Console.ReadLine();
            Console.Write("What is the card's defense value? ");
            string defense = Console.ReadLine();
            Console.Write("What is the card's pendulum effect? ");
            string pendulumEffect = Console.ReadLine();

            PendulumCard pendulumCard = new PendulumCard(name, effect, attribute, attack, defense, pendulumEffect);

            _cards.Add(pendulumCard);
        }
        else if (cardType == "3")
        {
            Console.Write("What is the name of the card? ");
            string name = Console.ReadLine();
            Console.Write("What is the card's effect text? ");
            string effect = Console.ReadLine();
            Console.Write("What is the card's attribute? ");
            string attribute = Console.ReadLine();
            Console.Write("What is the card's attack value? ");
            string attack = Console.ReadLine();
            Console.Write("What is the card's link rating? ");
            string linkRating = Console.ReadLine();

            LinkCard linkCard = new LinkCard(name, effect, attribute, attack, linkRating);

            _cards.Add(linkCard);
        }
        else if (cardType == "4")
        {
            Console.Write("What is the name of the card? ");
            string name = Console.ReadLine();
            Console.Write("What is the card's effect text? ");
            string effect = Console.ReadLine();
            Console.Write("What is the spell card's type? ");
            string type = Console.ReadLine();

            SpellCard spellCard = new SpellCard(name, effect, "Spell", type);

            _cards.Add(spellCard);
        }
        else if (cardType == "5")
        {
            Console.Write("What is the name of the card? ");
            string name = Console.ReadLine();
            Console.Write("What is the card's effect text? ");
            string effect = Console.ReadLine();
            Console.Write("What is the trap card's type? ");
            string type = Console.ReadLine();

            TrapCard trapCard = new TrapCard(name, effect, "Trap", type);

            _cards.Add(trapCard);
        }
        SaveCards("cards.txt");
    }
    public void CreateDeck()
    {
        Console.Write("Enter the name of the new deck: ");
        string deckName = Console.ReadLine();

        Deck deck = new Deck(deckName);
        _decks.Add(deck);
        deck.SaveDeck($"{deckName}.txt");

        Console.WriteLine("If you'd like to add cards to this deck return to the Main menu and select the view cards option.");
    }
    public void AddCardToDeck()
    {
        Console.Write("If you would like to add any of these cards to a deck type (Yes): ");
        string userInput = Console.ReadLine();
        userInput = userInput.ToLower();
        if (userInput == "yes")
        {
            string keepGoing = "yes";
            while ( keepGoing == "yes")
            {
                Console.Write("Please enter the Name of the card you'd like to look at: ");
                string cardName = Console.ReadLine();
                int indexNumber = -1;
                int cardIndex = 0;
                foreach ( Card c in _cards)
                {
                    indexNumber = indexNumber + 1;
                    if (cardName.ToLower() == c.GetCardName().ToLower())
                    {
                        Console.Clear();
                        c.DisplayCardInfo();
                        cardIndex = indexNumber;
                        keepGoing = "no";
                    }
                }

                if (keepGoing == "yes")
                {
                    Console.Write("The card name you entered doesn't correspond to any cards in the list. If you would like to enter it again type Yes: ");
                    keepGoing = Console.ReadLine().ToLower();
                }
                
                else if(keepGoing == "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add this card to a deck? Enter Yes or No");
                    string userResponse = Console.ReadLine().ToLower();
                    
            
                    if (userResponse == "yes")
                    {
                        Console.WriteLine("Enter the name of the deck you'd like to add it to: ");
                        string deckName = Console.ReadLine();
                        string deckInList = "no";
                        foreach(Deck d in _decks)
                        {
                            if (deckName == d.DisplayDeckName())
                            {
                                d.AddCardToDeck(cardIndex, _cards);
                                Console.WriteLine($"The card has been added to your {d.DisplayDeckName()} deck.");
                                deckInList = "yes";
                                d.SaveDeck($"{d.DisplayDeckName()}.txt");
                            }
                        }
                        if (deckInList == "no")
                        {
                            Console.WriteLine("The deck name you entered doesn't correspond with any of the decks in the list.");
                        }
                    }
                }
            }       
        }

    }
    public void ListCardsByType()
    {
        Console.Clear();
        Console.WriteLine("Which type of cards would you like to view?: ");
        Console.WriteLine(" 1. Monster Cards");
        Console.WriteLine(" 2. Spell and Trap Cards");
        Console.WriteLine(" 3. Return to main Menu");
        Console.Write("Select a choice from the menu: ");
        string userInput = Console.ReadLine();

        if (userInput == "1")
        {
            int number = 0;


            Console.WriteLine("Monster Cards:");
            foreach (Card c in _cards)
            {
                string attribute = c.GetAttribute();
                if (attribute != "Spell" && attribute != "Trap")
                {
                    number = number + 1;
                    Console.WriteLine($" {number}. {c.GetCardName()}");
                }

            }
            AddCardToDeck();
        }
        if (userInput == "2")
        {
            int number = 0;

            
            Console.WriteLine("Spell and Trap Cards:");
            foreach (Card c in _cards)
            {
                string attribute = c.GetAttribute();
                if (attribute == "Spell" || attribute == "Trap")
                {
                    number = number + 1;
                    Console.WriteLine($"{number}. {c.GetCardName()}");
                }
            }
            AddCardToDeck();
        }

    }
    public void ListDecks()
    {
        Console.WriteLine("Decks: ");
         
        int number = 0;
        foreach (Deck d in _decks)
        {
            number = number + 1;
            Console.WriteLine($"{number}. {d.DisplayDeckName()}");
        }

    }
    public void SaveCards(string file)
    {
        string fileName = file;
        
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Card c in _cards)
            {
                outputFile.WriteLine($"{c.GetCardRepresentation()}");
            }
        }
    }
    public void LoadCards(string file)
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
                    _cards.Add(newMonsterCard);
                }
                else if (parts[0] == "PendulumCard:")
                {
                    PendulumCard newPendulumCard = new PendulumCard(parts[1],parts[2],parts[3],parts[4],parts[5],parts[5]);
                    _cards.Add(newPendulumCard);
                }
                else if (parts[0] == "LinkCard:")
                {
                    LinkCard newLinkCard = new LinkCard(parts[1],parts[2],parts[3],parts[4],parts[5]);
                    _cards.Add(newLinkCard);
                }
                else if (parts[0] == "SpellCard:")
                {
                    SpellCard newSpellCard = new SpellCard(parts[1],parts[2],parts[3],parts[4]);
                    _cards.Add(newSpellCard);
                }
                else if (parts[0] == "TrapCard:")
                {
                    TrapCard newTrapCard = new TrapCard(parts[1],parts[2],parts[3],parts[4]);
                    _cards.Add(newTrapCard);
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