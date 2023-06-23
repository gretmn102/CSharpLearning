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
                _ => throw new NotImplementedException(battlerType.ToString()),
            };
        }
    }
}
