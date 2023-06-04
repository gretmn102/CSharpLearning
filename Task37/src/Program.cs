internal class Program
{
    public static void IEnumerablePrint<T>(IEnumerable<T> result)
    {
        foreach (var item in result)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }

    private static void Main()
    {
        // Лень писать что-то полноценное, потому воспользуюсь обычными множествами
        Console.Write("Первая коллекция: ");
        HashSet<int> firstSet = new() { 1, 2, 1 };
        IEnumerablePrint(firstSet);
        Console.Write("Вторая коллекция: ");
        HashSet<int> secondSet = new() { 3, 2 };
        IEnumerablePrint(secondSet);

        var resultSet = firstSet.Union(secondSet);
        Console.Write("Объеденная первая коллекция со второй: ");
        IEnumerablePrint(resultSet);
    }
}
