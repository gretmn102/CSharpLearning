namespace App
{
    class BattlerFactory
    {
        public static Battler CreateBattler(BattlerType battlerType)
        {

            return battlerType switch
            {
                BattlerType.Simpleton => new Battler(30, 5),
                BattlerType.Strongman => new Battler(60, 2),
                _ => throw new NotImplementedException(battlerType.ToString()),
            };
        }
    }
}
