internal class Program
{
    private static void Main()
    {
        int arrayLength = 30;
        int[] array = new int[arrayLength];

        Random r = new();
        for (int i = 0; i < arrayLength; i++)
        {
            array[i] = r.Next(0, 5);
        }

        // для проверки:
        // int[] array = new int[] {5, 5, 9, 9, 9, 5, 5};
        // int arrayLength = array.Length;

        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();

        int[] expArray = new int[arrayLength];
        array.CopyTo(expArray, 0);
        Array.Sort(expArray);

        // тупейшее решение в лоб:
        int minNum;
        int minIndex;
        for (int i = 0; i < arrayLength; i++)
        {
            minNum = array[i];
            minIndex = i;

            int currentNum;
            for (int j = i + 1; j < arrayLength; j++)
            {
                currentNum = array[j];
                if (currentNum < minNum)
                {
                    minNum = currentNum;
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                // int temp = array[i];
                // array[i] = array[minIndex];
                // array[minIndex] = temp;

                (array[minIndex], array[i]) = (array[i], array[minIndex]);
            }
        }

        Console.WriteLine("Отсортированный массив:");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();

        Console.WriteLine("Ожидаемый массив (должен совпасть):");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write($"{expArray[i]} ");
        }
        Console.WriteLine();
    }
}
