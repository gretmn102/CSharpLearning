internal class Program
{
    private static string PrintAndReadLine(string description, string defaultValue)
    {
        System.Console.Write(description);
        string? answer = System.Console.ReadLine();
        if (String.IsNullOrEmpty(answer))
        {
            return defaultValue;
        }
        return answer;
    }

    private static void Main(string[] args)
    {
        int imagesCount = 52;
        int rowImagesCount = 3;

        int fullRowsCount = imagesCount / rowImagesCount;

        int imagesLeftCount = imagesCount % rowImagesCount;

        Console.WriteLine($"Полностью заполненных рядов — {fullRowsCount}");
        Console.WriteLine($"Не вместилось изображений — {imagesLeftCount}");
    }
}
