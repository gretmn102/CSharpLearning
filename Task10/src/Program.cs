internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Введите кол-во элементов для генерации: ");
        int count = Int32.Parse(Console.ReadLine());

        int initNumber = 5;
        int diff = 7;

        for (int i = 0; i < count; i++)
        {
            int currentNumber = (i * diff) + initNumber;
            Console.Write($"{currentNumber} ");
        }
        Console.WriteLine();
    }
}
