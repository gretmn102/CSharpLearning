internal class Program
{
    private static void Main()
    {
        int shopBalance = 0;
        int[] purchaseSums = new int[] { 10, 20, 5, 3 };
        int length = purchaseSums.Length;
        int currentPurchaseSum;
        for (int i = 0; i < length; i++)
        {
            Console.Clear();
            currentPurchaseSum = purchaseSums[i];
            Console.WriteLine($"Баланс на счету магазина {shopBalance}");
            Console.WriteLine($"На кассу подходит клиент с суммой покупки на {currentPurchaseSum} у.е.");
            Console.WriteLine("(Нажмите любую клавишу, чтобы обслужить клиента)");
            Console.ReadKey();
            shopBalance += currentPurchaseSum;
        }
        Console.Clear();
        Console.WriteLine($"Все клиенты обслужены, очередь пуста, баланс на счету магазина составляет {shopBalance}. Хорошая работа.");
    }
}
