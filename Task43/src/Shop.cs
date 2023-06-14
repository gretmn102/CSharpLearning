namespace App
{
    class Shop
    {
        public Shop(ItemsContainer itemsContainer)
        {
            ItemsContainer = itemsContainer;
        }

        public ItemsContainer ItemsContainer { get; }
    }
}
