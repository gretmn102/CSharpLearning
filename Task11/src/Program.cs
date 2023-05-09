internal class Program
{
    private static void Main(string[] args)
    {
        Random r = new Random();
        int randomNumber = r.Next(1, 100);
        Console.WriteLine($"Случайное число — {randomNumber}");

        int acc = 0;
        Console.Write("Числа меньше этого числа (и оно в том числе), кратные 3 и 5: ");
        for (int i = 1; i <= randomNumber; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                Console.Write($"{i} ");
                acc += i;
            }
        }
        Console.WriteLine("");

        Console.WriteLine($"Сумма — {acc}");
    }
}
