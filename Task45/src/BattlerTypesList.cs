namespace App
{
    public class BattlerTypesList
    {
        public static readonly BattlerType[] Values = Enum.GetValues<BattlerType>();

        public static readonly Dictionary<BattlerType, string> ValuesRuNamesDictionary = new() {
            { BattlerType.Simpleton, "Дворокот" },
            { BattlerType.Dodger, "Ловкот" },
            { BattlerType.Berserk, "Берсерк" },
            { BattlerType.PatientMan, "Терплюн" },
            { BattlerType.Vampire, "Вампокот" },
            { BattlerType.Wizzard, "Валшекот" },
        };

        public static readonly string[] RuNames = ValuesRuNamesDictionary.Select(x => x.Value).ToArray();
    }
}
