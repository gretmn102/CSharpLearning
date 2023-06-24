namespace App
{
    class Controller
    {
        private GameState _gameState = null!;

        private string? _firstPlayerName;
        private BattlerType? _firstPlayerBattlerType;
        private string? _secondPlayerName;

        public Controller() { }

        public void Start()
        {
            View.GetFirstPlayerName(this);
        }

        public static GameState CreateGameState(
            string firstPlayerName,
            BattlerType firstPlayerBattlerType,
            string secondPlayerName,
            BattlerType secondPlayerBattlerType)
        {
            Battler firstPlayerBattler = BattlerFactory.CreateBattler(firstPlayerBattlerType);
            Player firstPlayer = new(firstPlayerName, firstPlayerBattler);

            Battler secondPlayerBattler = BattlerFactory.CreateBattler(secondPlayerBattlerType);
            Player secondPlayer = new(secondPlayerName, secondPlayerBattler);

            return new(firstPlayer, secondPlayer);
        }

        public void SetFirstPlayerName(string firstPlayerName)
        {
            _firstPlayerName = firstPlayerName;
            View.GetFirstPlayerBattlerType(this);
        }

        public void SetFirstPlayerBattlerType(BattlerType battlerType)
        {
            _firstPlayerBattlerType = battlerType;
            View.GetSecondPlayerName(this);
        }

        public void SetSecondPlayerName(string secondPlayerName)
        {
            _secondPlayerName = secondPlayerName;
            View.GetSecondPlayerBattlerType(this);
        }

        public void SetSecondPlayerBattleType(BattlerType secondPlayerbattlerType)
        {
            if (_firstPlayerName == null)
            {
                throw new Exception($"{nameof(_firstPlayerName)} must not be equal to null");
            }
            else if (!_firstPlayerBattlerType.HasValue)
            {
                throw new Exception($"{nameof(_firstPlayerBattlerType)} must not be equal to null");
            }
            else if (_secondPlayerName == null)
            {
                throw new Exception($"{nameof(_secondPlayerName)} must not be equal to null");
            }
            else
            {
                _gameState = CreateGameState(
                    _firstPlayerName,
                    _firstPlayerBattlerType.Value,
                    _secondPlayerName,
                    secondPlayerbattlerType);

                Player currentPlayer = _gameState.CurrentPlayer;
                View.NotifyPlayerMovesFirst(currentPlayer);
                StartMove();
            }
        }

        public void StartMove()
        {
            Player currentPlayer;
            Player attackedPlayer;
            currentPlayer = _gameState.CurrentPlayer;
            attackedPlayer = _gameState.OtherPlayer;
            View.GetBattlerActionType(this, currentPlayer, attackedPlayer);
        }

        public void Move(BattlerActionType actionType)
        {
            Player currentPlayer = _gameState.CurrentPlayer;
            Player attackedPlayer = _gameState.OtherPlayer;

            switch (actionType)
            {
                case BattlerActionType.Attack:
                    int? damage;

                    damage = _gameState.Attack();
                    if (!damage.HasValue)
                    {
                        View.NotifyDodge(currentPlayer, attackedPlayer);
                        _gameState.NextPlayer();
                        StartMove();
                        return;
                    }
                    else
                    {
                        View.NotifySuccessfulAttack(currentPlayer, attackedPlayer, damage.Value);

                        if (attackedPlayer.Battler.IsDead())
                        {
                            Player loser = attackedPlayer;
                            GameEnd(loser);
                            return;
                        }
                        else
                        {
                            _gameState.NextPlayer();
                            StartMove();
                            return;
                        }
                    }

                case BattlerActionType.Pass:
                    View.NotifyPass(currentPlayer, attackedPlayer);
                    _gameState.NextPlayer();
                    StartMove();
                    return;
            }
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
