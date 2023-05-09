internal class Program
{
    private static string PrintAndReadLine(string description, string defaultValue)
    {
        System.Console.Write(description);
        string? answer = System.Console.ReadLine();
        if (String.IsNullOrEmpty(answer))
        {
            return defaultValue;
        }
        return answer;
    }

    private static void Main(string[] args)
    {
        string name = PrintAndReadLine("Введите свое имя: ", "Анонимус");
        string birthYear = PrintAndReadLine("Введите свой год рождения: ", "???");
        string zodiac = PrintAndReadLine("Введите ваш знак зодиака: ", "???");
        string work = PrintAndReadLine("Вы работаете в/на: ", "???");

        Console.WriteLine($"Вас зовут {name}. Вам {birthYear} лет. Ваш знак зодиака — {zodiac}. Вы работает в/на {work}.");
    }
}
