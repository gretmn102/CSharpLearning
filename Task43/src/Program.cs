namespace App
{
    internal class Program
    {
        public static void Main()
        {
            Item[] items = new Item[] {
                new Item(ItemId.GenerateNew(), "Малый пузырек здоровья", 100, "Восполняет здоровье на 100HP"),
                new Item(ItemId.GenerateNew(), "Большой пузырек здоровья", 250, "Восполняет здоровье на 500HP")
            };

            ItemsContainer shopItemsContainer = new(items);
            Shop shop = new(shopItemsContainer);
            ItemsContainer heroItemsContainer = new();
            Hero hero = new(heroItemsContainer);

            View view = new(shop, hero);
            view.StartMenu();
        }
    }
}
