internal class Program
{
    const char startChar = '[';
    const char fullChar = '#';
    const char emptyChar = '_';
    const char endChar = ']';

    static void ProgressBarDisplay(string description, int value, int maxValue, int stepsCount = 10)
    {
        if (stepsCount <= 0)
        {
            throw new ArgumentException($"must be greater than or equal to zero", nameof(stepsCount));
        }

        if (!(0 <= value && value <= maxValue))
        {
            throw new ArgumentException($"must be greater than or equal to zero and less than or equal {maxValue}", nameof(value));
        }

        Console.Write(startChar);
        int stepLength = maxValue / stepsCount;
        int to = value / stepLength;
        for (int i = 0; i < to; i++)
        {
            Console.Write(fullChar);
        }
        for (int i = to; i < stepsCount; i++)
        {
            Console.Write(emptyChar);
        }
        Console.Write(endChar);
        Console.WriteLine($" {value}/{maxValue} {description}");
    }

    private static void Main()
    {
        ProgressBarDisplay("HP", 55, 250, 16);
        ProgressBarDisplay("MP", 55, 100, 13);
        ProgressBarDisplay("SP", 250, 1000);
    }
}
