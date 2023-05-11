internal class Program
{
    private enum CurrencyType
    {
        Unicorns,
        Faeries,
        Leprechauns
    }

    private static CurrencyType[] currencyTypes = Enum.GetValues<CurrencyType>();

    private static string GetCurrencyName(CurrencyType currencyType)
    {
        switch (currencyType)
        {
            case (CurrencyType.Faeries):
                return "феи";
            case (CurrencyType.Unicorns):
                return "единорогов";
            case (CurrencyType.Leprechauns):
                return "леприконов";
            default:
                throw new ArgumentException($"Unknown {currencyType}");
        }
    }

    private static double Convert(CurrencyType firstCurrencyType, CurrencyType secondCurrencyType, double currency)
    {
        var convertUnicornsToFaeries = (double unicorns) => unicorns * 3.0;
        var convertFaeriesToUnicorns = (double faeries) => faeries / 3.0;
        var convertFaeriesToLeprechauns = (double faeries) => faeries * 5.0;
        var convertLeprechaunsToFaeries = (double leprechauns) => leprechauns / 5.0;
        var convertUnicornsToLeprechauns = (double unicorns) => convertFaeriesToLeprechauns(convertUnicornsToFaeries(unicorns));
        var convertLeprechaunsToUnicorns = (double leprechauns) => convertFaeriesToUnicorns(convertLeprechaunsToFaeries(leprechauns));

        switch (firstCurrencyType, secondCurrencyType)
        {
            case (CurrencyType.Unicorns, CurrencyType.Faeries):
                return convertUnicornsToFaeries(currency);

            case (CurrencyType.Faeries, CurrencyType.Unicorns):
                return convertFaeriesToUnicorns(currency);

            case (CurrencyType.Faeries, CurrencyType.Leprechauns):
                return convertFaeriesToLeprechauns(currency);

            case (CurrencyType.Leprechauns, CurrencyType.Faeries):
                return convertLeprechaunsToFaeries(currency);

            case (CurrencyType.Unicorns, CurrencyType.Leprechauns):
                return convertUnicornsToLeprechauns(currency);

            case (CurrencyType.Leprechauns, CurrencyType.Unicorns):
                return convertLeprechaunsToUnicorns(currency);

            default:
                throw new ArgumentException($"unknown pair {firstCurrencyType} and {secondCurrencyType}");
        }
    }

    private static CurrencyType SelectCurrencyType(CurrencyType[] currencyTypes)
    {
        CurrencyType currencyType;
        for (int i = 0; i < currencyTypes.Length; i++)
        {
            currencyType = currencyTypes[i];
            Console.WriteLine($"{i + 1}) {GetCurrencyName(currencyType)}");
        }

        int currencyTypeIndex = 0;

        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out currencyTypeIndex))
            {
                if (0 < currencyTypeIndex && currencyTypeIndex <= currencyTypes.Length)
                {
                    break;
                }
            }

            Console.WriteLine($"Введите цифру от 1 до {currencyTypes.Length}");
        }

        return currencyTypes[currencyTypeIndex - 1];
    }

    //#region Balance
    private static int GetCurrencyIndex(CurrencyType currencyType)
    {
        switch (currencyType)
        {
            case CurrencyType.Unicorns:
                return 0;
            case CurrencyType.Faeries:
                return 1;
            case CurrencyType.Leprechauns:
                return 2;
            default:
                throw new ArgumentException($"unknown {currencyType} currencyType");
        }
    }

    private static double GetCurrency(double[] balance, CurrencyType currencyType)
    {
        return balance[GetCurrencyIndex(currencyType)];
    }

    private static void SetCurrency(double[] balance, CurrencyType currencyType, double value)
    {
        balance[GetCurrencyIndex(currencyType)] = value;
    }

    private static void PrintBalance(double[] balance)
    {
        for (int i = 0; i < balance.Length; i++)
        {
            double currencyValue = balance[i];
            string currencyName = GetCurrencyName(currencyTypes[i]);
            Console.WriteLine($"{i}) {currencyValue} {currencyName}");
        }
    }
    //#endregion

    private static void Main(string[] args)
    {
        // unicorns; faeries; leprechauns
        double[] balance = new double[3] { 10.0, 3.0, 5.0 };

        Console.WriteLine("Добро пожаловать в обменник. У вас с собой:");

        PrintBalance(balance);

        while (true) {
            Console.WriteLine("Выберите цифру валюты, чтобы ее обменять");

            CurrencyType firstSelectedCurrencyType = SelectCurrencyType(currencyTypes);
            string firstSelectedCurrencyName = GetCurrencyName(firstSelectedCurrencyType);

            Console.WriteLine($"Вы выбрали {firstSelectedCurrencyName}, теперь выберите цифру другой валюты, на которую хотите обменять");

            CurrencyType[] restCurrencyTypes =
                currencyTypes
                .Where(current => firstSelectedCurrencyType != current)
                .ToArray();

            CurrencyType secondSelectedCurrencyType = SelectCurrencyType(restCurrencyTypes);
            string secondSelectedCurrencyName = GetCurrencyName(secondSelectedCurrencyType);

            double firstCurrencyValue = GetCurrency(balance, firstSelectedCurrencyType);

            Console.WriteLine($"Вы меняете {firstSelectedCurrencyName} (которых у вас {firstCurrencyValue}) на {secondSelectedCurrencyName}");

            double count = Double.Parse(Console.ReadLine());

            double resultCurrencyValue = Convert(firstSelectedCurrencyType, secondSelectedCurrencyType, count);

            SetCurrency(balance, firstSelectedCurrencyType, firstCurrencyValue - count);

            SetCurrency(
                balance,
                secondSelectedCurrencyType,
                GetCurrency(balance, secondSelectedCurrencyType) + resultCurrencyValue
            );

            PrintBalance(balance);
        }
    }
}
