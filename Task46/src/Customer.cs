namespace App
{
    class Customer
    {
        public ProductBasket ProductBasket { get; }

        public int Money { get; set; }

        static readonly Random Random = new();

        public Customer(int money, int productBasketCapacity)
        {
            Money = money;
            ProductBasket = new ProductBasket(productBasketCapacity);
        }

        public void GetProduct(Supermarket supermarket, int supermarketProductIndex)
        {
            List<Product> products = supermarket.Products;
            ProductBasket.Add(products[supermarketProductIndex]);
            products.RemoveAt(supermarketProductIndex);
        }

        public void GetRandomProducts(Supermarket supermarket)
        {
            int minProducts = 0;
            int maxProducts = Math.Min(supermarket.Products.Count, ProductBasket.Capacity);
            for (int length = Random.Next(minProducts, maxProducts + 1);
                length > 0;
                length--)
            {
                GetProduct(supermarket, Random.Next(0, supermarket.Products.Count));
            }
        }

        public void GoToCheckout(Supermarket supermarket)
        {
            supermarket.Checkout.Enqueue(this);
        }

        public Product ReturnProduct(Supermarket supermarket, int productBasketIndex)
        {
            List<Product> products = supermarket.Products;
            Product product = ProductBasket[productBasketIndex];
            products.Add(product);
            ProductBasket.RemoveAt(productBasketIndex);
            return product;
        }

        public Product ReturnRandomProduct(Supermarket supermarket)
        {
            return ProductBasket.Count <= 0
                ? throw new Exception("Product basket is empty")
                : ReturnProduct(supermarket, Random.Next(0, ProductBasket.Count));
        }

        public override string ToString()
        {
            return $"Денег в кошельке: {Money}\nПродукты в корзинке:\n{ProductBasket}";
        }

        public static Customer CreateRandom(int minMoney, int maxMoney, int productBasketCapacity)
        {
            int money = Random.Next(minMoney, maxMoney + 1);
            Customer customer = new(money, productBasketCapacity);
            return customer;
        }
    }
}
