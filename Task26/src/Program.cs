internal class Program
{
    private static void Main()
    {
        string input = "Дана строка с текстом, используя метод строки `String.Split()` получить массив слов, которые разделены пробелом в тексте и вывести массив, каждое слово с новой строки.";
        string[] words = input.Split(" ");
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }
    }
}
