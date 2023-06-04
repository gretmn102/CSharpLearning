internal class Program
{
    private static void Main()
    {
        List<int> nums = new();

        while (true)
        {
            Console.WriteLine("Введите:");
            Console.WriteLine("* целочисленное число, чтобы записать его в программу;");
            Console.WriteLine("* команду `sum`, чтобы вывести сумму всех чисел;");
            Console.WriteLine("* либо команду `exit`, чтобы выйти из программы");

            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int currentNum))
            {
                nums.Add(currentNum);
            }
            else if (input == "sum")
            {
                int numsCount = nums.Count;
                if (numsCount <= 0)
                {
                    Console.WriteLine("Вы еще не ввели ни одного числа!");
                }

                int acc = 0;
                int current;
                for (int i = 0; i < numsCount; i++)
                {
                    current = nums[i];
                    acc += current;
                    Console.Write("{0}{1}", current, i < numsCount - 1 ? " + " : "");
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
