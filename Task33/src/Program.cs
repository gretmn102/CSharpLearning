internal class Program
{
    // Лучше всего такую задачу решать с помощью хэш-таблиц,
    // но я не знаю, можно ли их уже использовать или нет.
    // Ай, ладно, лень писать, поэтому использую Dictionary
    private static void Main()
    {
        Dictionary<string, string> dictionary = new()
        {
            { "сепульки", "важный элемент цивилизации ардритов (см.) с планеты Энтеропия (см.). См. СЕПУЛЬКАРИИ" },
            { "сепулькарии", "устройства для сепуления (см.)" },
            { "сепуление", "занятие ардритов (см.) с планеты Энтеропия (см.). См. СЕПУЛЬКИ" },
        };

        while (true)
        {
            Console.Write("Введите слово, чтобы узнать его значение: ");
            string word = (Console.ReadLine() ?? "").ToLower();
            if (!dictionary.TryGetValue(word, out string? definition))
            {
                Console.WriteLine("Слово не найдено!");
                continue;
            }

            Console.WriteLine($"{word} — {definition}");
        }
    }
}
