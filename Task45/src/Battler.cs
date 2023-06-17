namespace App
{
    class Battler
    {
        private int _hp;

        public int Hp
        {
            get { return _hp; }
            set { _hp = value < 0 ? 0 : value; }
        }
        public int Damage { get; }

        public bool IsDead()
        {
            return _hp <= 0;
        }

        public Battler(int hp, int damage)
        {
            Hp = hp;
            Damage = damage;
        }
    }
}
