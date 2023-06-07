namespace App
{
    readonly struct Card
    {
        public CardRank Rank { get; }
        public CardSuit Suit { get; }
        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        // оно должно быть вне этого класса, но я не знаю, куда его деть
        public static string? GetRankName(CardRank rank)
        {
            return rank switch
            {
                CardRank.Six => "6",
                CardRank.Seven => "7",
                CardRank.Eight => "8",
                CardRank.Nine => "9",
                CardRank.Ten => "10",
                CardRank.Jack => "Jack",
                CardRank.Queen => "Queen",
                CardRank.King => "King",
                CardRank.Ace => "Ace",
                _ => null,
            };
        }

        public static string? GetShortRankName(CardRank rank)
        {
            return rank switch
            {
                CardRank.Six => "6",
                CardRank.Seven => "7",
                CardRank.Eight => "8",
                CardRank.Nine => "9",
                CardRank.Ten => "10",
                CardRank.Jack => "J",
                CardRank.Queen => "Q",
                CardRank.King => "K",
                CardRank.Ace => "A",
                _ => null,
            };
        }

        // https://en.wikipedia.org/wiki/Playing_cards_in_Unicode#Card_suits
        public static string? GetSuitName(CardSuit suit)
        {
            return suit switch
            {
                CardSuit.Heart => "♥",
                CardSuit.Spade => "♠",
                CardSuit.Diamond => "♦",
                CardSuit.Club => "♣",
                _ => null,
            };
        }

        public override string ToString()
        {
            // при этом что делать, если захочется локализовать всё это дело? Фиг знает
            return $"{GetShortRankName(Rank)}{GetSuitName(Suit)}";
        }

        public bool Equals(Card other)
        {
            throw new NotImplementedException();
        }
    }
}
