namespace App
{
    class BattlerFactory
    {
        public static Battler CreateBattler(BattlerType battlerType)
        {

            return battlerType switch
            {
                BattlerType.Simpleton => new Battler(30, 5),
                BattlerType.Dodger => new Battler(15, 5)
                {
                    Dodgeable = new Dodgeable(0.3)
                },
                BattlerType.Berserk => new Battler(15, 5)
                {
                    Angreable = new Angreable(3),
                    AngryAttackable = new AngryAttackable(3, 3)
                },
                BattlerType.PatientMan => new Battler(20, 3)
                {
                    Patientable = new Patientable(3)
                },
                BattlerType.Vampire => new Battler(20, 3)
                {
                    LifeStealable = new LifeStealable(3)
                },
                _ => throw new NotImplementedException(battlerType.ToString()),
            };
        }
    }
}
