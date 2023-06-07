namespace App
{
    class Player
    {
        public string Id { get; }

        public string? Nickname { get; set; }

        public CardsContainer Hand { get; }

        public Player(string id)
        {
            Id = id;
            Hand = new();
        }

        public override string ToString()
        {
            return $"Id = {Id}, Nick = {Nickname}, Hand = {Hand}";
        }
    }
}
