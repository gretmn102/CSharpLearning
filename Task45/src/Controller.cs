namespace App
{
    class Controller
    {
        private GameState _gameState = null!;

        private string? _firstPlayerName;

        public Controller()
        {
        }

        public void Start()
        {
            View.GetFirstPlayerName(this);
        }

        public static Battler CreateBattler()
        {
            Battler firstPlayerBattler = new(30, 5);
            return firstPlayerBattler;
        }

        public static GameState CreateGameState(string firstPlayerName, string secondPlayerName)
        {
            Battler firstPlayerBattler = CreateBattler();
            Player firstPlayer = new(firstPlayerName, firstPlayerBattler);

            Battler secondPlayerBattler = CreateBattler();
            Player secondPlayer = new(secondPlayerName, secondPlayerBattler);

            return new(firstPlayer, secondPlayer);
        }

        public void SetFirstPlayerName(string firstPlayerName)
        {
            _firstPlayerName = firstPlayerName;
            View.GetSecondPlayerName(this);
        }

        public void SetSecondPlayerName(string secondPlayerName)
        {
            _gameState = CreateGameState(_firstPlayerName!, secondPlayerName);

            Player currentPlayer = _gameState.CurrentPlayer;
            View.NotifyPlayerMovesFirst(currentPlayer);
            StartMove();
        }

        public void StartMove()
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

                View.NotifyFightLog(currentPlayer, attackedPlayer, damage);

                if (attackedPlayer.Battler.IsDead())
                {
                    loser = attackedPlayer;
                    break;
                }

                _gameState.NextPlayer();
            }

            GameEnd(loser);
        }

        public void GameEnd(Player loser)
        {
            View.NotifyGameEnd(loser);
            View.GetIsStartAgain(this);
        }

        public void SetIsStartAgain(bool isStartAgain)
        {
            if (!isStartAgain)
            {
                return;
            }
            else
            {
                _gameState.Reset();
                StartMove();
            }
        }
    }
}
