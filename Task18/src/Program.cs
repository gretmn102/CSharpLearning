internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Type the expression: ");
            string input = Console.ReadLine() ?? "";
            int currentDeep = 0;
            int maxDeep = 0;
            bool isIncorrect = false;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                switch (c)
                {
                    case '(':
                        currentDeep++;
                        if (maxDeep < currentDeep)
                        {
                            maxDeep = currentDeep;
                        }
                        break;

                    case ')':
                        if (currentDeep <= 0)
                        {
                            Console.WriteLine($"Extra opening parenthesis at {i}.");
                            isIncorrect = true;
                            continue;
                        }
                        currentDeep--;
                        break;

                    default:
                        Console.WriteLine($"Unexpected '{c}' character at {i}.");
                        break;
                }
            }
            if (currentDeep > 0)
            {
                isIncorrect = true;
                Console.WriteLine($"Requires {currentDeep} closing parentheses");
            }

            if (isIncorrect)
            {
                Console.WriteLine("The expression is incorrect.");
            }

            Console.WriteLine($"Maximum nesting depth is {maxDeep}");
        }
    }
}
