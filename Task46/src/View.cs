namespace App
{
    internal class View
    {
        internal static void NotifyCustomerOnCheckout(Customer customer)
        {
            Console.WriteLine($"Клиент подошел к кассе:\n{customer}\n");
        }

        internal static void NotifyNotEnoughMoney(int totalCost, int money)
        {
            Console.WriteLine($"Общая сумма {totalCost}, но у клиента всего лишь {money}!");
        }

        internal static void NotifyCustomerReturnProduct(Product returnedProduct)
        {
            Console.WriteLine($"Клиент пошел выложил {returnedProduct}, вернулся и встал в конец очереди.");
        }

        internal static void NotifyCustomerIsServed()
        {
            Console.WriteLine("Клиент обслужен!");
        }

        internal static void NotifyCustomersAreAllServed()
        {
            Console.WriteLine("Все клиенты обслужены!");
        }
    }
}
