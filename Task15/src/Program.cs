internal class Program
{
    private static void Main(string[] args)
    {
        int maxAttemptsCount = 3;

        string veryStrongPassword = "12345";
        string secretMessage = "Не думай о розовом слоне.";

        int attemptsCount = 0;
        while (true)
        {
            Console.Write("Введите пароль, чтобы увидеть тайное послание: ");
            string typedPassword = Console.ReadLine() ?? "";
            if (typedPassword != veryStrongPassword)
            {
                attemptsCount++;
                if (attemptsCount >= maxAttemptsCount)
                {
                    Console.WriteLine("Попыток больше не осталось. Вы так и не смогли прочесть тайное послание.");
                    break;
                }

                Console.WriteLine($"Пароль неверный. Осталось {maxAttemptsCount - attemptsCount} попыток.");
                continue;
            }

            Console.WriteLine("Пароль верный. Секретное сообщение:");
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(secretMessage);
            Console.ForegroundColor = currentColor;
            break;
        }
    }
}
