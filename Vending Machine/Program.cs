using Vending_Machine;

namespace MyApplication
{
    public class Program
    {
        int[] moneyDenominations = { 5, 10, 20, 50, 100, 500, 1000 };
        static VendingMachine machine = new VendingMachine();
        static List<Product> boughtProducts = new List<Product>();
        static void Main(string[] args)
        {
            while (true)
            {
                machine.ShowAll();
                int val = Convert.ToInt32(Console.ReadLine());
                Product myProduct = machine.Purchase(val);
                boughtProducts.Add(myProduct);
            }


        }
    }
}