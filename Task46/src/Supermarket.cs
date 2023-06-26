namespace App
{
    class Supermarket
    {
        public List<Product> Products { get; }

        public Queue<Customer> Checkout { get; }

        public int Balance { get; set; }

        public Supermarket(int balance)
        {
            Balance = balance;
            Products = new();
            Checkout = new();
        }

        public static void FillRandomProducts(Supermarket supermarket)
        {
            Random random = new();

            Product[] possibleProducts = new Product[] {
                new Product("помидорка", 10),
                new Product("дыня", 20),
                new Product("огурец", 15),
                new Product("веник", 45)
            };
            int productsCount = random.Next(100, 200);

            int productIndex;
            var supermarketProducts = supermarket.Products;
            for (int i = 0; i < productsCount; i++)
            {
                productIndex = random.Next(0, possibleProducts.Length);
                supermarketProducts.Add(possibleProducts[productIndex]);
            }
        }
    }
}
