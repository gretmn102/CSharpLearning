internal class Program
{
    private static void Main()
    {
        int[,] matrix = new int[,] {
            {1, 2},
            {3, 4},
            {5, 6}
        };
        int width = matrix.GetLength(1);
        int height = matrix.GetLength(0);

        int sumSecondRow = 0;
        for (int x = 0; x < width; x++)
        {
            sumSecondRow += matrix[1, x];
        }
        Console.WriteLine($"Сумма второй строки — {sumSecondRow}");

        int productFirstColumn = 1;
        for (int y = 0; y < height; y++)
        {
            productFirstColumn *= matrix[y, 0];
        }
        Console.WriteLine($"Произведение первого столбца — {productFirstColumn}");
    }
}
