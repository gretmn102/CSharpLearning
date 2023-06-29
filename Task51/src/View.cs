namespace App
{
    internal class View
    {
        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("(Нажмите любую клавишу, чтобы продолжить)");
            Console.ReadKey();
        }
        public static void DisplayVillains(IEnumerable<Villain> villains)
        {
            foreach (var villain in villains)
            {
                Console.WriteLine(villain);
            }
            PressAnyKeyToContinue();
        }

        public static void DisplayFilteredVillains(VillainsQuery villainsQuery, IEnumerable<Villain> villains)
        {
            Console.WriteLine(villainsQuery);
            foreach (var villain in villains)
            {
                Console.WriteLine(villain);
            }
            PressAnyKeyToContinue();
        }

        public static void Menu(Controller controller)
        {
            Console.Clear();
            const string showAllVillains = "1";
            const string filterVillains = "2";
            Console.WriteLine($"{showAllVillains}. Вывести список преступников");
            Console.WriteLine($"{filterVillains}. Отсеять");
            switch (Console.ReadLine())
            {
                case showAllVillains:
                    Console.Clear();
                    controller.ShowAllVillains();
                    break;

                case filterVillains:
                    Console.Clear();
                    VillainsQuery mockVillainsQuery = new()
                    {
                        MinHeight = 190
                    }; // todo
                    controller.FilterVillains(mockVillainsQuery);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Неизвестная команда!");
                    PressAnyKeyToContinue();
                    Menu(controller);
                    break;
            }
        }
    }
}
