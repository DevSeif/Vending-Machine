namespace Vending_Machine
{
    public class VendingMachine : IVending
    {
        static VendingMachine machine = new VendingMachine();
        readonly static int[] moneyDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        static public int poolMoney = 0;
        static Dictionary<int, int> myDictionary = new Dictionary<int, int>();
        static List<Product> boughtProducts = new List<Product>();
        static public List<Product> products = new List<Product>
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
            int index = 1;
            foreach (Product product in products)
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

            foreach (int e in moneyDenominations.Reverse())
            {
                while (e <= poolMoney)
                {
                    myDictionary.Add(i, e);
                    i++;
                    poolMoney -= e;
                }
            }

            Dictionary<int, int> result = myDictionary;
            return result;
        }

        public bool CheckInput(int arg)
        {
            foreach (int e in moneyDenominations)
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

        public static void CheckBoughtProducts()
        {
            if (boughtProducts.Count == 0)
            {
                Console.WriteLine("Du har ingen produkt");
                return;
            }
            int i = 0;
            foreach (var product in boughtProducts)
            {
                Console.WriteLine($"\n[{i}] {product.Name}");
                i++;
            }
            Console.Write("Vilken produkt vill du använda: ");

            int val = Convert.ToInt32(Console.ReadLine());

            if (val <= boughtProducts.Count)
            {
                CheckProduct(val);
            }
            else
            {
                Console.WriteLine("Ogiltig input");
            }
        }

        static void CheckProduct(int index)
        {
            Product product = boughtProducts[index];
            Console.Write($"Vad vill du göra med din {product.Name}? \n1. Inspektera \n2. Använda \n:");
            int val = Convert.ToInt32(Console.ReadLine());
            switch (val)
            {
                case 1:
                    product.Examine();
                    break;
                case 2:
                    product.Use();
                    boughtProducts.RemoveAt(index);
                    break;
                default:
                    Console.WriteLine("Ogiltig input");
                    break;
            }
        }


        public static void InputMoney()
        {
            Console.Write("Lägg in sedlar eller mynt i vending machine\n (1, 5, 10, 20, 50, 100, 500 och 1000)\n: ");
            int moneyInput = Convert.ToInt32(Console.ReadLine());
            bool isCorrect = machine.CheckInput(moneyInput);
            if (isCorrect)
            {
                machine.InsertMoney(moneyInput);
                Vending();
            }
            else
            {
                Console.WriteLine("Ogiltig input! Försök igen");
                InputMoney();
            }

        }

        static void InsertOrEnd()
        {
            Console.Write("Vill du sätta in mer eller ta ut pengarna?\n1. Sätt in mer \n2. Ta ut \n: ");
            int val2 = Convert.ToInt32(Console.ReadLine());

            switch (val2)
            {
                case 1:
                    InputMoney();
                    break;
                case 2:
                    Dictionary<int, int> myDictionary = machine.EndTransaction();
                    Console.Write("Du får tillbaka ");
                    if (myDictionary.Count == 0) { Console.WriteLine("ingenting"); }
                    foreach (var e in myDictionary)
                    {
                        if (e.Value > 10) { Console.Write(e.Value + " lapp, "); }
                        else { Console.Write(e.Value + " mynt, "); }
                    }
                    myDictionary.Clear();
                    return;
                default:
                    Console.WriteLine("Ogiltig input");
                    InsertOrEnd();
                    break;
            }
        }
        static void Vending()
        {
            Console.WriteLine("Du har " + poolMoney + "kr i vending machine \n[0] Ta ut pengarna/Sätt in mer");
            machine.ShowAll();
            
                Console.Write(": ");
                
            try
            {
                int val = Convert.ToInt32(Console.ReadLine());

                if (val == 0)
                {
                    InsertOrEnd();
                }
                else if (val <= products.Count)
                {
                    bool isItEnough = machine.IsItEnough(val);
                    if (isItEnough)
                    {
                        Product purchasedProduct = machine.Purchase(val - 1);
                        boughtProducts.Add(purchasedProduct);
                        Vending();
                    }
                    else
                    {
                        Console.WriteLine("Du har inte råd\n");
                        Vending();
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltig input\n");
                    Vending();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ogiltig input");
                Vending();
            }

        }
    }
}
