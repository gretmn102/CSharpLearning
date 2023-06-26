namespace App
{
    readonly struct Product
    {
        public string Name { get; }

        public int Price { get; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} {Price}$";
        }
    }
}
