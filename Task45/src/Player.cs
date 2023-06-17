namespace App
{
    class Player
    {
        public string Name { get; set; }
        public Battler Battler { get; set; }

        public Player(string name, Battler battler)
        {
            Name = name;
            Battler = battler;
        }
    }
}
