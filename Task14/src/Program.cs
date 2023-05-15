internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Введите имя: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Введите символ для рамки: ");
        char frameChar = (char)Console.Read();

        for (int i = 0; i < 2 + name.Length + 2; i++)
        {
            Console.Write(frameChar);
        }
        Console.WriteLine();

        Console.WriteLine($"{frameChar} {name} {frameChar}");

        for (int i = 0; i < 2 + name.Length + 2; i++)
        {
            Console.Write(frameChar);
        }
        Console.WriteLine();
    }
}
