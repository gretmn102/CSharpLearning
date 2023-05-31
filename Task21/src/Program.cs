internal class Program
{
    private static void Main()
    {
        int[,] matrix = new int[10,10];
        int width = matrix.GetLength(1);
        int height = matrix.GetLength(0);

        Random r = new();
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                matrix[y, x] = r.Next(1, 21);
            }
        }

        Console.WriteLine("Исходная матрица:");
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write("{0}{1}", matrix[y, x], x == width - 1 ? "" : ", ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        int max = int.MinValue;
        int current;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                current = matrix[y, x];
                if (current > max)
                {
                    max = current;
                }
            }
        }

        Console.WriteLine($"Наибольший элемент — {max}");
        Console.WriteLine();

        Console.WriteLine("Итоговая матрица:");
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                current = matrix[y, x];
                Console.Write("{0}{1}",
                    current < max ? current : 0,
                    x == width - 1 ? "" : ", ");
            }
            Console.WriteLine();
        }
    }
}
