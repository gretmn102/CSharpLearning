namespace App
{
    class Dodgeable
    {
        private double _chance;
        private readonly Random _random = new();

        /// <summary>Number that is greater than or equal to 0.0, and less than or equal to 1.0</summary>
        public double Chance
        {
            get { return _chance; }
            set
            {
                _chance = 0.0 <= value ? (value <= 1.0 ? value : 1.0) : 0.0;
            }
        }

        public Dodgeable(double chance) => Chance = chance;

        public bool CalcIsDodge() => _random.NextDouble() <= Chance;
    }
}
