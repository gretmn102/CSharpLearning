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
                BattlerType.Wizzard => new Battler(15, 3)
                {
                    Manable = new Manable(60),
                    Fireballable = new Fireballable(20, 8)
                },
                _ => throw new NotImplementedException(battlerType.ToString()),
            };
        }
    }
}
