namespace App
{
    class Fireballable
    {
        public int ManaCost { get; set; }

        public int Damage { get; set; }

        public Fireballable(int manaCost, int damage)
        {
            ManaCost = manaCost;
            Damage = damage;
        }

        public IBattlerActionResult Cast(Battler current, Battler enemy)
        {
            Manable? manable = current.Manable;
            if (manable == null)
            {
                // it looks more like an exception than a variant of the result value
                // it might be worth changing it to an exception
                return new BattlerIsNotAngryable();
            }
            else if (manable.Current < ManaCost)
            {
                return new NotEnoughMana();
            }
            else if (enemy.CalcIsDodge())
            {
                return new EnemyDodged();
            }
            else
            {
                manable.Current -= ManaCost;

                int damage = Damage;
                enemy.Hp -= damage;

                enemy.Patientable?.Restore(enemy);

                return new SuccessfulAttack(damage);
            }
        }
    }
}
