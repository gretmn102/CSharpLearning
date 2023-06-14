namespace App
{
    internal class HeroShopModel
    {
        readonly Hero _hero;
        readonly Shop _shop;

        public HeroShopModel(Hero hero, Shop shop)
        {
            _hero = hero;
            _shop = shop;
        }

        public Shop Shop => _shop;

        public Hero Hero => _hero;

        public void BuyItem(int index)
        {
            ItemsContainer shopItemsContainer = Shop.ItemsContainer;
            Item selectedItem = shopItemsContainer[index];
            shopItemsContainer.RemoveAt(index);
            _hero.ItemsContainer.Add(selectedItem);
        }

        public void SellItem(int index)
        {
            ItemsContainer heroItemsContainer = _hero.ItemsContainer;
            Item selectedItem = heroItemsContainer[index];
            heroItemsContainer.RemoveAt(index);
            Shop.ItemsContainer.Add(selectedItem);
        }
    }
}
