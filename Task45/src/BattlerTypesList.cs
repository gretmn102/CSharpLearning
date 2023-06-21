namespace App
{
    public class BattlerTypesList
    {
        public static readonly BattlerType[] Values = Enum.GetValues<BattlerType>();

        public static readonly Dictionary<BattlerType, string> ValuesRuNamesDictionary = new() {
            { BattlerType.Simpleton, "Дворокот" },
            { BattlerType.Strongman, "Силокот" },
        };

        public static readonly string[] RuNames = ValuesRuNamesDictionary.Select(x => x.Value).ToArray();
    }
}
