internal class Program
{
    public static void ArrayRemoveAt<T>(ref T[] arr, int index)
    {
        if (!(0 <= index && index < arr.Length)) {
            throw new ArgumentException("index must be greater than or equal to zero and less than the length of the array", nameof(index));
        }
        int length = arr.Length - 1;

        for (int i = index; i < length; i++)
        {
            arr[i] = arr[i + 1];
        }
        Array.Resize(ref arr, length);
    }

    private static void ArrayShuffle<T>(ref T[] srcArray)
    {
        Random r = new();
        int srcArrayLength = srcArray.Length;

        int length = srcArrayLength;
        T[] shuffledArray = new T[length];

        int randomSrcArrayIndex;
        for (int i = 0; i < length; i++)
        {
            randomSrcArrayIndex = r.Next(0, srcArrayLength);
            shuffledArray[i] = srcArray[randomSrcArrayIndex];
            ArrayRemoveAt(ref srcArray, randomSrcArrayIndex);
            srcArrayLength--;
        }
        srcArray = shuffledArray;
    }

    private static void ArrayPrint<T>(ref T[] array)
    {
        int length = array.Length;
        for (int i = 0; i < length; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();
    }

    private static void Main()
    {
        int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine("Исходный массив:");
        ArrayPrint(ref array);
        ArrayShuffle(ref array);
        Console.WriteLine("Перемешанный массив:");
        ArrayPrint(ref array);
    }
}
