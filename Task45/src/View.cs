namespace App
{
    internal class View
    {
        GameState _gameState = null!;

        public void CreatePlayers()
        {
            Console.Write("Назови себя, первый игрок: ");
            string firstPlayerName = ConsoleHelpers.ReadLine("Имярек1");
            Battler firstPlayerBattler = new(30, 5);
            Player firstPlayer = new(firstPlayerName, firstPlayerBattler);

            Console.Write("Назови себя, второй игрок: ");
            string secondPlayerInput = ConsoleHelpers.ReadLine("Имярек2");
            Battler secondPlayerBattler = new(30, 5);
            Player secondPlayer = new(secondPlayerInput, secondPlayerBattler);

            _gameState = new(firstPlayer, secondPlayer);
            Player currentPlayer = _gameState.CurrentPlayer;
            Console.WriteLine($"Игрок {currentPlayer.Name} ходит первым.");
        }

        private Player GameLoop()
        {
            Player currentPlayer;
            Player attackedPlayer;
            int damage;
            Player? loser = null;
            while (loser == null)
            {
                currentPlayer = _gameState.CurrentPlayer;
                attackedPlayer = _gameState.OtherPlayer;

                damage = currentPlayer.Battler.Damage;
                attackedPlayer.Battler.Hp -= damage;
                Console.WriteLine($"Котец {currentPlayer.Name} куськает котца {attackedPlayer.Name} и наносит {damage} кусьрона! У того остается {attackedPlayer.Battler.Hp} терпения.");

                if (attackedPlayer.Battler.IsDead())
                {
                    loser = attackedPlayer;
                    break;
                }

                _gameState.NextPlayer();
            }

            return loser;
        }

        public void Start()
        {
            CreatePlayers();

            bool isContinue = true;
            while (isContinue)
            {
                Player? loser = GameLoop();
                Console.WriteLine($"{loser.Name} проиграл!");
                Console.WriteLine("P.S. ни один котец во время драки не пострадал.");

                Console.Write("Сразиться еще раз? (д/н): ");
                isContinue = ConsoleHelpers.YesOrNo();
            }
        }
    }
}
