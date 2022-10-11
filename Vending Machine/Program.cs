using System.Collections.ObjectModel;
using Vending_Machine;

namespace MyApplication
{
    public class Program
    {
        
        static VendingMachine machine = new VendingMachine();
        static List<Product> boughtProducts = new List<Product>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\n\n1. Använd vending machine \n2. Kolla vad du har köpt \n: ");
                try
                {
                    int val = Convert.ToInt32(Console.ReadLine());
                
                switch (val)
                {
                    case 1:
                        InputMoney();
                        break;
                    case 2:
                        CheckBoughtProducts();
                        break;
                }
                }
                catch
                {
                    Console.WriteLine("Ogiltig input");
                }
            }

        }

        static void CheckBoughtProducts()
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


        static void InputMoney()
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
        static void Vending()
        {
            Console.WriteLine("Du har " + machine.poolMoney + "kr i vending machine \n[0] Ta ut pengarna");
            machine.ShowAll();
            try
            {
                int val = Convert.ToInt32(Console.ReadLine());

                if (val == 0)
                {
                    Dictionary<int, int> myDictionary = machine.EndTransaction();
                    Console.Write("Du får tillbaka ");
                    foreach (var e in myDictionary)
                    {
                        if (e.Value > 10) { Console.Write(e.Value + " lapp, "); }
                        else { Console.Write(e.Value + " mynt, "); }
                    }
                    return;
                }
                else if (val <= machine.GetProductLength())
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
                        Console.WriteLine("Du har inte råd");
                        Vending();
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltig input");
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