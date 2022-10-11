using System.Collections.ObjectModel;

namespace Vending_Machine
{
    public class VendingMachine : IVending
    {
        static int[] moneyDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        static ReadOnlyCollection<int> moneyReadOnly = new ReadOnlyCollection<int>(moneyDenominations);
        public int poolMoney = 0;
        Dictionary<int, int> myDictionary = new Dictionary<int, int>();
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
            //argIndex++;
            Product product = products[argIndex];
            poolMoney -= products[argIndex].Price;
            products.RemoveAt(argIndex);
            return product;
        }

        public void ShowAll()
        {
            int index = 1;
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

        public Dictionary<int, int> EndTransaction()
        {
            int i = 1;

            foreach (int e in moneyReadOnly.Reverse())
            {
                while (e <= poolMoney)
                {
                    myDictionary.Add(i, e);
                    i++;
                    poolMoney -= e;
                }
            }
            return myDictionary;

        }

        public bool CheckInput(int arg)
        {
            foreach (int e in moneyReadOnly)
            {
                if (arg == e) { return true; }
            }
            return false;
        }

        public bool IsItEnough(int argIndex)
        {
            if (poolMoney >= products[argIndex - 1].Price)
            {
                return true;
            }
            return false;
        }

        public int GetProductLength() { return products.Count; }
    }
}
