internal class Program
{
    /// <summary>
    /// Удаляет предмет по указанному индексу и сдвигает массив справа налево
    /// </summary>
    public static void ArrayRemoveAt<T>(ref T[] arr, int index)
    {
        if (!(0 <= index && index < arr.Length))
        {
            throw new ArgumentException("index must be greater than or equal to zero and less than the length of the array", nameof(index));
        }
        int length = arr.Length - 1;

        for (int i = index; i < length; i++)
        {
            arr[i] = arr[i + 1];
        }
        Array.Resize(ref arr, length);
    }

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

    private static object[][] _profiles = Array.Empty<object[][]>();
    private static int _profilesLength = 0;

    public static void AddProfile(string fullName, string position)
    {
        Array.Resize(ref _profiles, _profilesLength + 1);
        _profiles[_profilesLength] = ProfileInit(_profilesLength, fullName, position);
        _profilesLength++;
    }

    public static void RemoveProfile(int index)
    {
        ArrayRemoveAt(ref _profiles, index);
        _profilesLength--;
    }

    public static object[]? SearchProfileByFullName(string pattern)
    {
        string lowerPattern = pattern.ToLower();
        string fullName;
        object[] profile;
        for (int i = 0; i < _profilesLength; i++)
        {
            profile = _profiles[i];
            fullName = ProfileGetFullName(profile).ToLower();
            if (fullName.Contains(lowerPattern))
            {
                return profile;
            }
        }
        return null;
    }

    private static void UiPrintProfiles()
    {
        if (_profilesLength == 0)
        {
            Console.WriteLine("Список досье пуст!");
            return;
        }

        Console.WriteLine("Индекс | Имя | Занимая должность");
        object[] profile;
        string fullName;
        string position;
        for (int i = 0; i < _profilesLength; i++)
        {
            profile = _profiles[i];
            fullName = ProfileGetFullName(profile);
            position = ProfileGetPosition(profile);
            Console.WriteLine($"{i} | {fullName} | {position}");
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
        if (_profilesLength == 0)
        {
            Console.WriteLine("Список досье пуст!");
            return;
        }

        Console.WriteLine("Введите индекс досье, которое хотите удалить");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            if (!(0 <= index && index < _profilesLength))
            {
                Console.WriteLine($"Индекс должен быть от 0 (включительно) до {_profilesLength}!");
                return;
            }

            Console.WriteLine($"Удаляю:");
            Console.WriteLine(ProfileToString(_profiles[index]));

            RemoveProfile(index);
            Console.WriteLine("Досье успешно удалено!");
        }
    }

    private static void UiSearchProfileByFullName()
    {
        Console.Write("Введите фамилию, имя или отчество (можно частично): ");
        string pattern = Console.ReadLine() ?? "";

        object[]? profile = SearchProfileByFullName(pattern);
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
