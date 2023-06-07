namespace App
{
    class Deck
    {
        CardsContainer _cards;

        public int Count => _cards.Count;

        public Deck()
        {
            _cards = CardsContainer.GenerateAllCards();
        }

        public Card? TakeTopCard()
        {
            if (_cards.Count <= 0)
            {
                return null;
            }
            else
            {
                Card topCard = _cards.Cards[0];
                _cards.Cards.RemoveAt(0);
                return topCard;
            }
        }

        public void Shuffle()
        {
            var cards = _cards.Cards;
            int count = cards.Count;
            List<Card> shuffledCards = new(count);
            Random r = new();
            int randomIndex;
            for (int i = 0; i < count; i++)
            {
                randomIndex = r.Next(0, cards.Count);
                shuffledCards.Add(cards[randomIndex]);
                cards.RemoveAt(randomIndex);
            }
            _cards.Cards = shuffledCards;
        }

        public void Reset()
        {
            _cards = CardsContainer.GenerateAllCards();
        }

        public override string ToString()
        {
            var cards = _cards.Cards;
            int count = cards.Count;
            string[] stringCards = new string[count];
            for (int i = 0; i < count; i++)
            {
                stringCards[i] = cards[i].ToString() ?? "?";
            }
            return string.Join(", ", stringCards);
        }
    }
}
