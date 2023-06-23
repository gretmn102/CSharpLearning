namespace App
{
    class Battler
    {
        private int _maxHp;
        public int MaxHp
        {
            get { return _maxHp; }
            set
            {
                _maxHp = value;
                if (_hp > value)
                {
                    _hp = value;
                }
            }
        }

        private int _hp;
        public int Hp
        {
            get { return _hp; }
            set { _hp = 0 < value ? (value <= _maxHp ? value : _maxHp) : 0; }
        }

        public int Damage { get; }

        public Dodgeable? Dodgeable { get; set; }

        public int? Attack(Battler enemy)
        {
            Dodgeable? dodgeable = enemy.Dodgeable;
            if (dodgeable != null && dodgeable.CalcIsDodge())
            {
                return null;
            }
            else
            {
                enemy.Hp -= Damage;
                return Damage;
            }
        }

        public void Reset()
        {
            Hp = _maxHp;
        }

        public bool IsDead()
        {
            return _hp <= 0;
        }

        public Battler(int maxHp, int damage)
        {
            _maxHp = maxHp;
            _hp = maxHp;
            Damage = damage;
        }
    }
}
