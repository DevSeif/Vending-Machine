namespace Vending_Machine
{
    public class VendingMachine : IVending
    {
        public int poolMoney = 1000;
        List<Product> products = new List<Product>
        {
            new Snack(12, "Snickers"),
            new Snack(12, "Snickers"),
            new Snack(12, "Snickers"),
            new Snack(12, "Snickers"),
            new Snack(10, "Kex"),
            new Snack(10, "Kex"),
            new Snack(15, "Marabou"),
            new Snack(15, "Marabou"),
            new Snack(25, "Doritos"),
            new Drink(12, "Pepsi"),
            new Drink(12, "Pepsi"),
            new Drink(12, "Fanta"),
            new Drink(12, "Coca Cola"),
            new Cigarette(60, "Marlboro paket"),
            new Cigarette(60, "Marlboro paket"),
            new Cigarette(60, "Winston paket"),
            new Cigarette(500, "Kubansk cigarette"),
        };
        public Product Purchase(int argIndex)
        {
            Product product = products[argIndex];
            poolMoney -= products[argIndex].Price;
            products.RemoveAt(argIndex);
            return product;
        }

        public void ShowAll()
        {
            int index = 0;
            foreach(Product product in products)
            {
                Console.WriteLine($"[{index}] {product.Name} {product.Price}kr");
                index++;
            }
        }

        public void InsertMoney(int money)
        {
            poolMoney += money;
        }

        public int EndTransaction()
        {
            int temp = poolMoney;
            poolMoney = 0;
            return temp;
        }
    }
}
