namespace App
{
    class GameState
    {
        readonly Player _firstPlayer;

        public Player FirstPlayer => _firstPlayer;

        readonly Player _secondPlayer;

        public Player SecondPlayer => _secondPlayer;

        readonly int _playersLength = 2;

        int _currentPlayerIndex = 0;

        public int CurrentPlayerIndex
        {
            get { return _currentPlayerIndex; }

            set
            {
                if (0 > _currentPlayerIndex || _currentPlayerIndex >= _playersLength)
                {
                    // Где-то слышал, что нельзя фигачить исключения в свойствах, надо это дело изучить
                    string argName = nameof(_currentPlayerIndex);
                    throw new ArgumentException($"must be greater than or equal zero and lower than {nameof(_playersLength)}", argName);
                }
                else
                {
                    _currentPlayerIndex = value;
                }
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return _currentPlayerIndex switch
                {
                    0 => _firstPlayer,
                    1 => _secondPlayer,
                    _ => throw new Exception($"{nameof(_currentPlayerIndex)} = {_currentPlayerIndex} not implemented yet"),
                };
            }
        }

        public Player OtherPlayer
        {
            get
            {
                return _currentPlayerIndex switch
                {
                    0 => _secondPlayer,
                    1 => _firstPlayer,
                    _ => throw new Exception($"{nameof(_currentPlayerIndex)} = {_currentPlayerIndex} not implemented yet"),
                };
            }
        }

        public void NextPlayer()
        {
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _playersLength;
        }

        public GameState(Player firstPlayer, Player secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
        }
    }
}
