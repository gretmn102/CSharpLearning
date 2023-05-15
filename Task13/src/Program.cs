internal class Program
{
    private static void Main(string[] args)
    {
        const string setNameCommandName = "SetName";
        const string setNameCommandDescription = "Назначить имя пользователя";
        const string writeNameCommandName = "WriteName";
        const string writeNameCommandDescription = "Выводит текущее имя пользователя";
        const string changeConsoleColorCommand = "ChangeConsoleColor";
        const string changeConsoleColorCommandDescription = "Сменить цвет в консоли";
        const string getConsoleColorsCommand = "GetConsoleColors";
        const string getConsoleColorsCommandDescription = "Выводит доступные цвета для консоли";
        const string setPasswordCommandName = "SetPassword";
        const string setPasswordDescription = "Установить пароль";
        const string helpCommandName = "Help";
        const string helpCommandDescription = "Вывести справку по доступным командам";
        const string escCommandName = "Esc";
        const string escCommandDescription = "Выйти из приложения";
        (string, string)[] commands = new (string, string)[] {
            (setNameCommandName, setNameCommandDescription),
            (writeNameCommandName, writeNameCommandDescription),
            (setPasswordCommandName, setPasswordDescription),
            (getConsoleColorsCommand, getConsoleColorsCommandDescription),
            (changeConsoleColorCommand, changeConsoleColorCommandDescription),
            (helpCommandName, helpCommandDescription),
            (escCommandName, escCommandDescription),
        };

        string[] colorNames = Enum.GetNames<ConsoleColor>();
        ConsoleColor[] colorValues = Enum.GetValues<ConsoleColor>();
        Dictionary<string, ConsoleColor> consoleColors =
            new Dictionary<string, ConsoleColor>(
                colorNames
                .Zip(colorValues)
                .Select((x) => KeyValuePair.Create(x.First, x.Second))
            );

        string commandNamesMessage =
            String.Format(
                "Доступны следующие команды: {0}.",
                String.Join(", ", commands.Select(command => command.Item1))
            );

        string commandsMessage =
            String.Format(
                "Доступны следующие команды:\n{0}",
                String.Join("\n", commands.Select(command => $"  {command.Item1} — {command.Item2}"))
            );

        string? name = null;
        string? password = null;

        bool isContinue = true;
        while (isContinue)
        {
            Console.Write("Введите команду: ");
            string? rawCommand = Console.ReadLine();
            switch (rawCommand)
            {
                case setNameCommandName:
                    Console.Write("Введите имя: ");
                    name = Console.ReadLine();
                    break;
                case writeNameCommandName:
                    if (password is null)
                    {
                        Console.WriteLine($"Сперва установите пароль командой \"{setPasswordCommandName}\"");
                    }
                    else
                    {
                        if (name is null)
                        {
                            Console.WriteLine($"Сперва установите имя с помощью команды \"{setNameCommandName}\"");
                        }
                        else
                        {
                            Console.Write("Введите пароль: ");
                            if (Console.ReadLine() == password)
                            {
                                Console.WriteLine($"Ваше имя — {name}");
                            }
                            else
                            {
                                Console.WriteLine("Пароль неверный, доступ запрещен!");
                            }
                        }
                    }
                    break;
                case setPasswordCommandName:
                    if (password is null)
                    {
                        Console.Write("Введите пароль: ");
                        password = Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("Для установления нового пароля введите старый пароль: ");
                        if (Console.ReadLine() == password)
                        {
                            Console.Write("Введите пароль: ");
                            password = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Пароль неверный, доступ запрещен!");
                        }
                    }
                    break;
                case changeConsoleColorCommand:

                    Console.Write("Введите цвет консоли: ");
                    string? rawColor = Console.ReadLine();

                    string notFoundColorMessage = $"Цвет {rawColor} не найден. Введите команду \"{getConsoleColorsCommand}\", чтобы узнать все доступные цвета.";

                    if (rawColor is null)
                    {
                        Console.WriteLine(notFoundColorMessage);
                    }
                    else
                    {
                        System.ConsoleColor color;
                        if (consoleColors.TryGetValue(rawColor, out color))
                        {
                            Console.ForegroundColor = color;
                        }
                        else
                        {
                            Console.WriteLine(notFoundColorMessage);
                        }
                    }
                    break;
                case getConsoleColorsCommand:
                    Console.WriteLine("Доступные цвета для консоли: {0}", String.Join(", ", colorNames));
                    break;
                case helpCommandName:
                    Console.WriteLine(commandsMessage);
                    break;
                case escCommandName:
                    isContinue = false;
                    break;
                default:
                    Console.WriteLine($"Неизвестная команда {rawCommand}.\n{commandNamesMessage}");
                    break;
            }
        }
    }
}
