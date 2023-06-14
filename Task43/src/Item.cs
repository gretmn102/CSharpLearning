namespace App
{
    class Item
    {
        public ItemId Id { get; set; }
        public string Name { get; }
        public int Price { get; }
        public string Description { get; }

        public Item(ItemId itemId, string name, int price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
            Id = itemId;
        }

        public override string ToString()
        {
            return $"{Id}, \"{Name}\", {Price}, {Description}";
        }
    }
}
