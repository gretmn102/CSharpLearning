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

        public static BattlerType SelectBattlerType()
        {
            Console.WriteLine("Выберите цифрой класс котца:");

            int i = 1;
            foreach (string name in BattlerTypesList.RuNames)
            {
                Console.WriteLine($"{i}. {name}");
                i++;
            }

            int selectedIndex = ConsoleHelpers.ReadInt(1, BattlerTypesList.Values.Length + 1) - 1;
            return BattlerTypesList.Values[selectedIndex];
        }

        public static void GetFirstPlayerBattlerType(Controller controller)
        {
            BattlerType battlerType = SelectBattlerType();
            controller.SetFirstPlayerBattlerType(battlerType);
        }

        public static void GetSecondPlayerName(Controller controller)
        {
            Console.Write("Назови себя, второй игрок: ");
            string secondPlayerInput = ConsoleHelpers.ReadLine("Имярек2");
            controller.SetSecondPlayerName(secondPlayerInput);
        }

        public static void GetSecondPlayerBattlerType(Controller controller)
        {
            BattlerType battlerType = SelectBattlerType();
            controller.SetSecondPlayerBattleType(battlerType);
        }

        public static void NotifyPlayerMovesFirst(Player player)
        {
            Console.WriteLine($"Игрок {player.Name} ходит первым.");
        }

        public static void NotifyAttack(Player currentPlayer, Player attackedPlayer, int damage)
        {
            Console.WriteLine($"Котец {currentPlayer.Name} куськает котца {attackedPlayer.Name} и наносит {damage} кусьрона! У того остается {attackedPlayer.Battler.Hp} терпения.");
        }

        public static void NotifyDodge(Player currentPlayer, Player attackedPlayer)
        {
            Console.WriteLine($"Котец {attackedPlayer.Name} увернулся от котца {currentPlayer.Name}!");
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
