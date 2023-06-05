namespace App
{
    class Player
    {
        public PlayerId Id { get; }
        public string? Nickname { get; set; }
        public int Level { get; set; }
        public bool IsBanned { get; set; }

        public Player(PlayerId id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Id = {Id}, Nick = {Nickname}, Level = {Level}, IsBanned = {IsBanned}";
        }
    }
}
