namespace App
{
    class AngryAttackable
    {
        public int AngryCost { get; set; }

        public int DamageMultiplier { get; set; }

        public AngryAttackable(int angryCost, int damageMultiplier)
        {
            AngryCost = angryCost;
            DamageMultiplier = damageMultiplier;
        }

        public IBattlerActionResult Attack(Battler current, Battler enemy)
        {
            Angreable? angreable = current.Angreable;
            if (angreable == null)
            {
                // it looks more like an exception than a variant of the result value
                // it might be worth changing it to an exception
                return new BattlerIsNotAngryable();
            }
            else if (angreable.Current < AngryCost)
            {
                return new NotEnoughAngry();
            }
            else if (enemy.CalcIsDodge())
            {
                return new EnemyDodged();
            }
            else
            {
                int damage = current.Damage * DamageMultiplier;
                enemy.Hp -= damage;
                angreable.Current -= AngryCost;
                return new SuccessfulAttack(damage);
            }
        }
    }
}
