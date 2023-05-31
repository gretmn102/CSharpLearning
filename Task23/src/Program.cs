internal class Program
{
    private static void Main()
    {
        // всякий раз, когда массив переполняется, то он увеличивается на это число:
        int arrayIncreasingCount = 2;
        // разумнее, конечно, удваивать массив, но это не интересно.

        int arrayLength = 3;
        int[] array = new int[arrayLength];
        int arrayFilledCount = 0;

        while (true)
        {
            Console.WriteLine("Введите:");
            Console.WriteLine("* целочисленное число, чтобы записать его в программу;");
            Console.WriteLine("* команду `sum`, чтобы вывести сумму всех чисел;");
            Console.WriteLine("* либо команду `exit`, чтобы выйти из программы");

            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int currentNum))
            {
                if (arrayFilledCount >= arrayLength)
                {
                    Console.WriteLine($"Массив переполнен! Увеличиваю массив на {arrayIncreasingCount}");
                    arrayLength += arrayIncreasingCount;
                    int[] tempArray = new int[arrayLength];
                    for (int i = 0; i < arrayFilledCount; i++)
                    {
                        tempArray[i] = array[i];
                    }
                    array = tempArray;
                }

                array[arrayFilledCount] = currentNum;
                arrayFilledCount++;
            }
            else if (input == "sum")
            {
                if (arrayFilledCount <= 0)
                {
                    Console.WriteLine("Вы еще не ввели ни одного числа!");
                }

                int acc = 0;
                int current;
                for (int i = 0; i < arrayFilledCount; i++)
                {
                    current = array[i];
                    acc += current;
                    Console.Write("{0}{1}", current, i < arrayFilledCount - 1 ? " + " : "");
                }
                Console.WriteLine($" = {acc}");
            }
            else if (input == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine($"'{input}' — неизвестная команда!");
            }
        }
    }
}
