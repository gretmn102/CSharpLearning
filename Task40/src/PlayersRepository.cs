namespace App
{
    using System.Collections;

    class PlayersRepository : IEnumerable<Player>
    {
        private readonly Dictionary<PlayerId, Player> _players;

        public int Count => _players.Count;

        public PlayersRepository()
        {
            _players = new();
        }

        public Player Insert(Player newPlayer)
        {
            _players.Add(newPlayer.Id, newPlayer);
            return newPlayer;
        }

        public Player? GetValue(PlayerId id)
        {
            if (_players.TryGetValue(id, out Player? player))
            {
                return player;
            }
            return null;
        }

        public bool Update(Player player)
        {
            return _players.TryAdd(player.Id, player);
        }

        IEnumerator<Player> IEnumerable<Player>.GetEnumerator()
        {
            IEnumerable<KeyValuePair<PlayerId, Player>> ie = _players;
            var enumerator = ie.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerable<KeyValuePair<PlayerId, Player>> ie = _players;
            var enumerator = ie.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current.Value;
            }
        }
    }
}
