using Vending_Machine;

namespace MyApplication
{
    public class Program
    {
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
                        VendingMachine.InputMoney();
                        break;
                    case 2:
                        VendingMachine.CheckBoughtProducts();
                        break;
                }
                }
                catch
                {
                    Console.WriteLine("Ogiltig input");
                }
            }

        }

        
    }
}