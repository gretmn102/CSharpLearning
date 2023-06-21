namespace App
{
    internal class View
    {
        public static void GetFirstPlayerName(Controller controller)
        {
            Console.Write("Назови себя, первый игрок: ");
            string firstPlayerName = ConsoleHelpers.ReadLine("Имярек1");
            controller.SetFirstPlayerName(firstPlayerName);
        }

        public static void GetSecondPlayerName(Controller controller)
        {
            Console.Write("Назови себя, второй игрок: ");
            string secondPlayerInput = ConsoleHelpers.ReadLine("Имярек2");
            controller.SetSecondPlayerName(secondPlayerInput);
        }

        public static void NotifyPlayerMovesFirst(Player player)
        {
            Console.WriteLine($"Игрок {player.Name} ходит первым.");
        }

        public static void NotifyFightLog(Player currentPlayer, Player attackedPlayer, int damage)
        {
            Console.WriteLine($"Котец {currentPlayer.Name} куськает котца {attackedPlayer.Name} и наносит {damage} кусьрона! У того остается {attackedPlayer.Battler.Hp} терпения.");
        }

        public static void NotifyGameEnd(Player loser)
        {
            Console.WriteLine($"{loser.Name} проиграл!");
            Console.WriteLine("P.S. ни один котец во время драки не пострадал.");
        }

        public static void GetIsStartAgain(Controller controller)
        {
            Console.Write("Сразиться еще раз? (д/н): ");
            bool isStartAgain = ConsoleHelpers.YesOrNo();
            controller.SetIsStartAgain(isStartAgain);
        }
    }
}
