internal class Program
{
    private static void Main(string[] args)
    {
        {
            string firstName = "Грозный";
            string lastName = "Иван";

            string temp;
            temp = firstName;
            firstName = lastName;
            lastName = temp;

            Console.WriteLine($"Твое имя — {firstName}, а фамилия — {lastName}");
        }

        // а потом всё это дело можно вывести в отдельный метод:
        {
            Console.WriteLine("");
            Console.WriteLine("Решение через `FlipTwoStrings` — метод, который принимает две строки и переопределяет значение переменных:");

            string firstName = "Грозный";
            string lastName = "Иван";

            FlipTwoStrings(ref firstName, ref lastName);

            Console.WriteLine($"Твое имя — {firstName}, а фамилия — {lastName}");
        }

        // Теперь FlipTwoStrings можно обобщить, чтобы он принимал два значения любого типа
        {
            Console.WriteLine("");
            Console.WriteLine("Решение через `Flip` — обобщенный метод:");

            string firstName = "Грозный";
            string lastName = "Иван";

            int firstNumber = 2;
            int secondNumber = 1;

            Flip(ref firstName, ref lastName);
            Flip(ref firstNumber, ref secondNumber);

            Console.WriteLine($"Твое имя — {firstName}, а фамилия — {lastName}");
            Console.WriteLine($"Первое число — {firstNumber}, а второе — {secondNumber}");
        }
    }

    private static void FlipTwoStrings(ref string first, ref string second)
    {
        string temp;
        temp = first;
        first = second;
        second = temp;
    }

    private static void Flip<T>(ref T first, ref T second)
    {
        T temp;
        temp = first;
        first = second;
        second = temp;
    }
}
