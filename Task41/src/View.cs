namespace App
{
    class View
    {
        readonly Deck deck = new();
        readonly Player player = new("Player1");

        public View() { }

        public static bool YesOrNo()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "да":
                        return true;
                    case "нет":
                        return false;
                    default:
                        Console.WriteLine("Введите 'да' или 'нет'");
                        break;
                }
            }
        }

        public void StartGame()
        {
            deck.Shuffle();

            while (true)
            {
                Console.WriteLine($"В колоде — {deck.Count} карт(ы).");

                if (player.Hand.Count == 0)
                {
                    Console.WriteLine("У тебя пока что нет карт на руке.");
                }
                else
                {
                    Console.WriteLine($"Твои карты: {player.Hand}.");
                }

                Console.WriteLine("Взять еще (да/нет)?");

                bool isContinue = YesOrNo();
                if (!isContinue)
                {
                    break;
                }

                Card? card = deck.TakeTopCard();
                if (!card.HasValue)
                {
                    Console.WriteLine("В колоде карт больше не осталось!");
                    break;
                }
                else
                {
                    player.Hand.Cards.Add(card.Value);
                }
            }
        }
    }
}
