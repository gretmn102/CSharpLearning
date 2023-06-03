internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.Write("Введите целочисленное число: ");
            string userInput = Console.ReadLine() ?? "";
            if (int.TryParse(userInput, out int number))
            {
                Console.WriteLine($"Вы ввели {number}");
                break;
            }
            Console.WriteLine($"`{userInput}` — не число!");
        }
    }
}
