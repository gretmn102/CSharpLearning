namespace App
{
    class Controller
    {
        const int ProductBasketCapacity = 10;

        readonly Random _random = new();

        public void CreateCustomers(Supermarket supermarket)
        {
            int customersCount = _random.Next(0, 10);
            for (int i = 0; i < customersCount; i++)
            {
                Customer customer = Customer.CreateRandom(10, 100, ProductBasketCapacity);
                customer.GetRandomProducts(supermarket);
                customer.GoToCheckout(supermarket);
            }
        }

        public static void ServeCustomers(Supermarket supermarket)
        {
            Queue<Customer> checkout = supermarket.Checkout;

            while (true)
            {
                if (checkout.Count <= 0)
                {
                    View.NotifyCustomersAreAllServed();
                    break;
                }
                else
                {
                    Customer customer = checkout.Dequeue();
                    View.NotifyCustomerOnCheckout(customer);
                    int totalCost = customer.ProductBasket.CalcTotalCost();
                    int money = customer.Money;
                    if (money < totalCost)
                    {
                        View.NotifyNotEnoughMoney(money, totalCost);
                        Product returnedProduct = customer.ReturnRandomProduct(supermarket);
                        supermarket.Checkout.Enqueue(customer);
                        View.NotifyCustomerReturnProduct(returnedProduct);
                    }
                    else
                    {
                        supermarket.Balance += totalCost;
                        View.NotifyCustomerIsServed();
                    }
                }
            }
        }

        public void Start()
        {
            Supermarket supermarket = new(0);

            Supermarket.FillRandomProducts(supermarket);

            CreateCustomers(supermarket);

            ServeCustomers(supermarket);
        }
    }
}
