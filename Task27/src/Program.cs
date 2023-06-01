internal class Program
{
    private static void Main()
    {
        int arrayLength = 10;
        int[] array = new int[arrayLength];
        for (int i = 0; i < arrayLength; i++)
        {
            array[i] = i;
        }

        // деление по модулю нужно в случае, если пользователь введет число больше длины исходного массива
        int shift = -3 % arrayLength;

        int[] resultArray = new int[arrayLength];
        int diff = arrayLength - shift;
        for (int i = 0; i < arrayLength; i++)
        {
            resultArray[i] = array[(diff + i) % arrayLength];
        }

        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();

        Console.WriteLine($"Итоговый массив, сдвинутый на {shift}:");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write($"{resultArray[i]} ");
        }
        Console.WriteLine();
    }
}
