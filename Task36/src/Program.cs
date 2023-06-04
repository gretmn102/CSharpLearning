internal class Program
{
    // Поскольку структуры еще недоступны, то для представления данных используется массив объектов,
    // в котором первый элемент — id, второй — фио, а третий — занимая должность.
    public static object[] ProfileInit(int id, string fullName, string position)
    {
        return new object[] { id, fullName, position };
    }

    public static int ProfileGetId(object[] profile)
    {
        return (int)profile[0];
    }

    public static string ProfileGetFullName(object[] profile)
    {
        return (string)profile[1];
    }

    public static string ProfileGetPosition(object[] profile)
    {
        return (string)profile[2];
    }

    public static string ProfileToString(object[] profile)
    {
        return String.Concat(
            $"Индекс: {ProfileGetId(profile)}", "\n",
            $"ФИО: {ProfileGetFullName(profile)}", "\n",
            $"Должность: {ProfileGetPosition(profile)}");
    }

    private static int _lastProfileId = 0;
    private static readonly Dictionary<int, object[]> _profiles = new();

    public static void AddProfile(string fullName, string position)
    {
        _profiles.Add(_lastProfileId, ProfileInit(_lastProfileId, fullName, position));
        _lastProfileId++;
    }

    public static bool RemoveProfile(int id)
    {
        return _profiles.Remove(id);
    }

    public static object[]? SearchProfileByFullName(string pattern)
    {
        string lowerPattern = pattern.ToLower();
        string currentFullName;
        foreach (var (profileId, profile) in _profiles)
        {
            currentFullName = ProfileGetFullName(profile).ToLower();
            if (currentFullName.Contains(lowerPattern))
            {
                return profile;
            }
        }

        return null;
    }

    private static void UiPrintProfiles()
    {
        if (_profiles.Count == 0)
        {
            Console.WriteLine("Список досье пуст!");
            return;
        }

        Console.WriteLine("Индекс | Имя | Занимая должность");
        string fullName;
        string position;
        foreach (var (profileId, profile) in _profiles)
        {
            fullName = ProfileGetFullName(profile);
            position = ProfileGetPosition(profile);
            Console.WriteLine($"{profileId} | {fullName} | {position}");
        }
    }

    private static void UiAddProfile()
    {
        Console.Write("Введите фамилию, имя и отчество: ");
        string fullName = Console.ReadLine() ?? "";
        Console.Write("Введите занимаемую должность: ");
        string position = Console.ReadLine() ?? "";
        AddProfile(fullName, position);
        Console.WriteLine("Досье добавлено!");
    }

    private static void UiRemoveProfile()
    {
        if (_profiles.Count == 0)
        {
            Console.WriteLine("Список досье пуст!");
            return;
        }

        Console.WriteLine("Введите индекс досье, которое хотите удалить");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (!_profiles.TryGetValue(id, out var profile))
            {
                Console.WriteLine($"Досье с индексом {id} не найдено");
                return;
            }
            Console.WriteLine($"Удаляю:");
            Console.WriteLine(ProfileToString(profile));

            RemoveProfile(id);
            Console.WriteLine("Досье успешно удалено!");
        }
    }

    private static void UiSearchProfileByFullName()
    {
        Console.Write("Введите фамилию, имя или отчество (можно частично): ");
        string pattern = Console.ReadLine() ?? "";

        var profile = SearchProfileByFullName(pattern);
        if (profile == null)
        {
            Console.WriteLine($"Досье по запросу '{pattern}' не найдено!");
            return;
        }

        Console.WriteLine("Найдено следующее досье:");
        Console.WriteLine(ProfileToString(profile));
    }

    private static void Main()
    {
        bool isContinue = true;
        while (isContinue)
        {
            Console.WriteLine("Введите команду цифрой:");
            Console.WriteLine("1. добавить досье");
            Console.WriteLine("2. вывести все досье");
            Console.WriteLine("3. удалить досье");
            Console.WriteLine("4. поиск по фамилии");
            Console.WriteLine("5. выход");

            string rawUserCommand = Console.ReadLine() ?? "";
            switch (rawUserCommand)
            {
                case "1":
                    UiAddProfile();
                    break;
                case "2":
                    UiPrintProfiles();
                    break;
                case "3":
                    UiRemoveProfile();
                    break;
                case "4":
                    UiSearchProfileByFullName();
                    break;
                case "5":
                    isContinue = false;
                    break;
                default:
                    Console.WriteLine($"`{rawUserCommand}` — неизвестная команда");
                    break;
            }
        }
    }
}
