namespace App
{
    internal class View
    {
        readonly Shop _shop;
        readonly Hero _hero;

        public View(Shop shop, Hero hero)
        {
            _shop = shop;
            _hero = hero;
        }

        public static void PressToContinue()
        {
            Console.WriteLine("(Нажмите любую кнопку, чтобы продолжить)");
            Console.ReadKey();
        }

        static public void DisplayItems(IEnumerable<Item> items)
        {
            int index = 0;
            foreach (Item item in items)
            {
                Console.WriteLine($"{index}. {item}");
                index++;
            }
        }

        public void BuyItem()
        {
            ItemsContainer shopItemsContainer = _shop.ItemsContainer;
            int? index = DisplayAndSelectItem(shopItemsContainer);
            if (index.HasValue)
            {
                Item selectedItem = shopItemsContainer[index.Value];
                shopItemsContainer.RemoveAt(index.Value);
                _hero.ItemsContainer.Add(selectedItem);
                Console.WriteLine($"Вы купили \"{selectedItem.Name}\", спасибо еще!");
            }

            PressToContinue();
        }

        public void SellItem()
        {
            ItemsContainer heroItemsContainer = _hero.ItemsContainer;
            int? index = DisplayAndSelectItem(heroItemsContainer);
            if (index.HasValue)
            {
                Item selectedItem = heroItemsContainer[index.Value];
                heroItemsContainer.RemoveAt(index.Value);
                _shop.ItemsContainer.Add(selectedItem);
                Console.WriteLine($"Вы продали \"{selectedItem.Name}\", спасибо еще!");
            }

            PressToContinue();
        }

        public static int? DisplayAndSelectItem(ItemsContainer shopItemsContainer)
        {
            int count = shopItemsContainer.Count;
            if (count <= 0)
            {
                Console.WriteLine("Предметов больше нет");
                return null;
            }
            else
            {
                Console.WriteLine($"Выберите предмет от 0 (включительно) до {count} из следующего списка:");
                DisplayItems(shopItemsContainer);
                int selectedIndex = ConsoleHelpers.ReadInt(0, count);
                Item selectedItem = shopItemsContainer[selectedIndex];
                Console.WriteLine($"Вы хотите выбрать \"{selectedItem.Name}\"? (д/н)");
                if (!ConsoleHelpers.YesOrNo())
                {
                    Console.WriteLine("Ну и ладно!");
                    return null;
                }
                else
                {
                    return selectedIndex;
                }
            }
        }

        public void Menu()
        {
            Console.WriteLine("1. Купить предмет");
            Console.WriteLine("2. Продать предмет");

            string? rawUserCommand = Console.ReadLine();
            switch (rawUserCommand)
            {
                case "1":
                    BuyItem();
                    break;

                case "2":
                    SellItem();
                    break;

                default:
                    Console.WriteLine($"Неизвестная '{rawUserCommand}' команда");
                    PressToContinue();
                    break;
            }
        }

        public void StartMenu()
        {
            while (true)
            {
                Console.Clear();
                Menu();
            }
        }
    }
}
