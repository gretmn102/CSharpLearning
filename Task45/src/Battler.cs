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

        public Angreable? Angreable { get; set; }

        public AngryAttackable? AngryAttackable { get; set; }

        public bool CalcIsDodge()
        {
            Dodgeable? dodgeable = Dodgeable;
            return dodgeable != null && dodgeable.CalcIsDodge();
        }

        public IBattlerActionResult Attack(Battler enemy)
        {
            if (Angreable != null)
            {
                Angreable.Current++;
            }

            if (enemy.CalcIsDodge())
            {
                return new EnemyDodged();
            }
            else
            {
                enemy.Hp -= Damage;
                return new SuccessfulAttack(Damage);
            }
        }

        public List<BattlerActionType> GetPossibleActionTypes()
        {
            List<BattlerActionType> actionTypes = new()
            {
                BattlerActionType.Attack
            };

            if (AngryAttackable != null)
            {
                actionTypes.Add(BattlerActionType.AngryAttack);
            }

            actionTypes.Add(BattlerActionType.Pass);

            return actionTypes;
        }

        public void Reset()
        {
            Hp = _maxHp;
        }

        public bool IsDead()
        {
            return _hp <= 0;
        }

        public IBattlerActionResult AngryAttack(Battler enemy)
        {
            if (AngryAttackable == null)
            {
                return new BattlerIsNotAngryable();
            }
            else
            {
                return AngryAttackable.Attack(this, enemy);
            }
        }

        public Battler(int maxHp, int damage)
        {
            _maxHp = maxHp;
            _hp = maxHp;
            Damage = damage;
        }
    }
}
