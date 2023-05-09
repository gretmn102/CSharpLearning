internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Введите сообщение: ");
        string message = Console.ReadLine();

        Console.Write("Введите кол-во повторений: ");
        int count = Int32.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{message} x{i + 1}");
        }
    }
}
