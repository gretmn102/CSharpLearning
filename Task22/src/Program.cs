internal class Program
{
    private static void Main()
    {
        int[] array = new int[30];
        int length = array.Length;

        Random r = new();
        for (int i = 0; i < length; i++)
        {
            array[i] = r.Next(1, 21);
        }

        Console.WriteLine("Сгенерированный массив:");
        for (int i = 0; i < length; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();

        Console.WriteLine("Локальные максимумы:");
        for (int i = 0; i < length; i++)
        {
            if (i == 0)
            {
                Console.Write(Math.Max(array[i], array[i + 1]));
            }
            else if (i == length - 1)
            {
                Console.Write(Math.Max(array[i - 1], array[i]));
            }
            else
            {
                Console.Write(
                    Math.Max(Math.Max(array[i - 1], array[i]), array[i + 1]));
            }
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}
