namespace App
{
    class BattlerActionTypeList
    {
        public static readonly BattlerActionType[] Values = Enum.GetValues<BattlerActionType>();

        public static readonly Dictionary<BattlerActionType, string> ValuesRuNamesDictionary = new() {
            { BattlerActionType.Attack, "Атаковать" },
            { BattlerActionType.Pass, "Пропустить" },
        };

        public static readonly string[] RuNames = ValuesRuNamesDictionary.Select(x => x.Value).ToArray();
    }
}
