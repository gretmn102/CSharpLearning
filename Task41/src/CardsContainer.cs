namespace App
{
    class CardsContainer
    {
        public List<Card> Cards { get; set; }

        public int Count => Cards.Count;

        public override string ToString()
        {
            int count = Cards.Count;
            string[] stringCards = new string[count];
            for (int i = 0; i < count; i++)
            {
                stringCards[i] = Cards[i].ToString() ?? "?";
            }
            return string.Join(", ", stringCards);
        }

        public void Add(Card card)
        {
            Cards.Add(card);
        }

        public CardsContainer()
        {
            Cards = new();
        }

        public CardsContainer(List<Card> cards)
        {
            Cards = cards;
        }

        public static CardsContainer GenerateAllCards()
        {
            CardRank[] ranks = Enum.GetValues<CardRank>();
            CardSuit[] suits = Enum.GetValues<CardSuit>();
            List<Card> cards = new(ranks.Length * suits.Length);
            foreach (var rank in ranks)
            {
                foreach (var suit in suits)
                {
                    cards.Add(new Card(rank, suit));
                }
            }
            return new CardsContainer(cards);
        }
    }
}
