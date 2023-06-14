namespace App
{
    class Hero
    {
        public ItemsContainer ItemsContainer { get; }
        public Hero(ItemsContainer itemsContainer)
        {
            ItemsContainer = itemsContainer;
        }
    }
}
