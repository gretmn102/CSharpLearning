internal class Program
{
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
