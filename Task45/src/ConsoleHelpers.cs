namespace App
{
    public static class ConsoleHelpers
    {
        public static int ReadInt()
        {
            string input;
            int result;
            while (true)
            {
                input = Console.ReadLine() ?? "";
                if (!int.TryParse(input, out result))
                {
                    Console.WriteLine("Число не распознано! Попробуйте еще раз.");
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public static int ReadInt(int from, int to)
        {
            if (from >= to)
            {
                throw new ArgumentException($"{nameof(from)} must be lower than {nameof(to)}!");
            }
            else
            {
                int input;
                while (true)
                {
                    input = ReadInt();
                    if (from > input || input >= to)
                    {
                        Console.WriteLine($"Индекс должен быть больше или равен {from} и быть меньше, чем {to}!");
                    }
                    else
                    {
                        return input;
                    }
                }
            }
        }

        public static bool YesOrNo()
        {
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "д":
                        return true;
                    case "н":
                        return false;
                    default:
                        Console.WriteLine("Введите \"д\", либо \"н\" (без кавычек!)");
                        break;
                }
            }
        }

        public static string ReadLine(string defaultValue)
        {
            string userInput = Console.ReadLine() ?? defaultValue;
            return userInput switch
            {
                null or "" => defaultValue,
                _ => userInput,
            };
        }
    }
}
