internal class Program
{
    private static void Main(string[] args)
    {
        Random r = new Random();

        int targetNumber;
        while (true)
        {
            Console.WriteLine("Введите положительно целочисленное 32-битное число (либо оставьте поле пустым, чтобы сгенерировать случайное): ");
            string rawTargetNumber = Console.ReadLine() ?? "";

            if (rawTargetNumber == "")
            {
                targetNumber = r.Next(0, Int32.MaxValue);
                break;
            }

            if (Int32.TryParse(rawTargetNumber, out targetNumber))
            {
                break;
            }

            continue;
        }

        targetNumber = Math.Abs(targetNumber);

        int currentNumber = 1;
        int currentPowerOfTwo = 0;
        while (true)
        {
            if (currentNumber > targetNumber)
            {
                break;
            }

            currentNumber *= 2;
            currentPowerOfTwo++;

            // если к Int32.MaxValue прибавить 1, то число станет отрицательным из-за переполнения
            // цикл будет мотать бесконечно, если не сделать следующее условие:
            if (currentNumber < 0)
            {
                currentNumber = -1; // чтобы явно показать переполнение числа
                break;
            }
        }

        Console.WriteLine($"2^{currentPowerOfTwo} = {currentNumber} — минимальная степень двойки, превосходящая {targetNumber}.");
    }
}
