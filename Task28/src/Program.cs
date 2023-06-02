internal class Program
{
    /// Удаляет предмет по указанному индексу и сдвигает массив справа налево
    public static void ArrayRemoveAt<T>(ref T[] arr, int index)
    {
        if (!(0 <= index && index < arr.Length)) {
            throw new ArgumentException("index must be greater than or equal to zero and less than the length of the array", nameof(index));
        }
        int length = arr.Length - 1;

        for (int i = index; i < length; i++)
        {
            arr[i] = arr[i + 1];
        }
        Array.Resize(ref arr, length);
    }

    private static string [] _fullNames = Array.Empty<string>();
    private static string [] _positions = Array.Empty<string>();
    private static int _profilesLength = 0;

    public static string ToStringProfile(int index)
    {
        if (!(0 <= index && index < _profilesLength)) {
            throw new ArgumentException("index must be greater than or equal to zero and less than the length of the array", nameof(index));
        }

        return String.Concat(
            $"Индекс: {index}", "\n",
            $"ФИО: {_fullNames[index]}", "\n",
            $"Должность: {_positions[index]}");
    }

    public static void AddProfile(string fullName, string position)
    {
        Array.Resize(ref _fullNames, _profilesLength + 1);
        _fullNames[_profilesLength] = fullName;
        Array.Resize(ref _positions, _profilesLength + 1);
        _positions[_profilesLength] = position;
        _profilesLength++;
    }

    public static void RemoveProfile(int index)
    {
        ArrayRemoveAt(ref _fullNames, index);
        ArrayRemoveAt(ref _positions, index);
        _profilesLength--;
    }

    public static int SearchProfileByFullName(string pattern)
    {
        string lowerPattern = pattern.ToLower();
        string currentFullName;
        for (int i = 0; i < _profilesLength; i++)
        {
            currentFullName = _fullNames[i].ToLower();
            if (currentFullName.Contains(lowerPattern))
            {
                return i;
            }
        }
        return -1;
    }

    private static void UiPrintProfiles()
    {
        if (_profilesLength == 0)
        {
            Console.WriteLine("Список досье пуст!");
            return;
        }

        Console.WriteLine("Индекс | Имя | Занимая должность");
        for (int i = 0; i < _profilesLength; i++)
        {
            Console.WriteLine($"{i} | {_fullNames[i]} | {_positions[i]}");
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
            Console.WriteLine(ToStringProfile(index));

            RemoveProfile(index);
            Console.WriteLine("Досье успешно удалено!");
        }
    }

    private static void UiSearchProfileByFullName()
    {
        Console.Write("Введите фамилию, имя или отчество (можно частично): ");
        string pattern = Console.ReadLine() ?? "";

        int resultIndex = SearchProfileByFullName(pattern);
        if (resultIndex < 0)
        {
            Console.WriteLine($"Досье по запросу '{pattern}' не найдено!");
            return;
        }

        Console.WriteLine("Найдено следующее досье:");
        Console.WriteLine(ToStringProfile(resultIndex));
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
