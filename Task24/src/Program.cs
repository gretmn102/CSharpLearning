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

        int? maxNum = null;
        int maxNumCount = 0;

        int currentNum;
        int? lastNum = null;
        int lastNumCount = 0;
        for (int i = 0; i < arrayLength; i++)
        {
            currentNum = array[i];
            if (lastNum.HasValue && currentNum != lastNum)
            {
                if (lastNumCount > maxNumCount)
                {
                    maxNum = lastNum;
                    maxNumCount = lastNumCount;
                }

                lastNum = currentNum;
                lastNumCount = 1;
                continue;
            }

            lastNum = currentNum;
            lastNumCount++;
        }

        Console.WriteLine($"Наибольшее число — {maxNum}, оно повторяется {maxNumCount} раз(а).");
    }
}
