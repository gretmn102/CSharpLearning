internal class Program
{
    private static void Main(string[] args)
    {
        // параметры игрока:
        int playerGoldsCount = 100;
        int playerCrystalsCount = 0;

        // параметры кристалла:
        int crystalCost = 25;

        Console.WriteLine("Вы заходите в лавку кристаллов, где с порога на вас обрушивается здоровенный продавец с приветственной речью:");
        Console.WriteLine($"— Добро пожаловать в мою скромную лавку кристаллов, путник! Стоимость одного кристалла — всего лишь {crystalCost} золотых! Сколько кристаллов желаете купить?");
        Console.WriteLine("(Пожалуйста, введите целочисленное число, а то программа рухнет, хо-хо)");
        int crystalWantToBuy = Int32.Parse(Console.ReadLine());

        playerGoldsCount -= crystalCost * crystalWantToBuy;
        playerCrystalsCount += crystalWantToBuy;

        Console.WriteLine($"— Прекрасно! Спасибо за покупку!");
        Console.WriteLine("");
        Console.WriteLine("Теперь у вас в инвентаре:");
        Console.WriteLine($"* {playerGoldsCount} золота;");
        Console.WriteLine($"* {playerCrystalsCount} кристаллов");
    }
}
