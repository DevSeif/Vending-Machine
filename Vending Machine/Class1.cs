namespace Vending_Machine
{
    public class Snack : Product
    {
        public Snack(int price, string name) : base(price, name)
        {
        }

        public override void Use()
        {
            Console.WriteLine("Du äter upp din " + Name);
        }
    }

    public class Drink : Product 
    {
        public Drink(int price, string name) : base(price, name)
        {
        }

        public override void Use()
        {
            Console.WriteLine("Du dricker upp din " + Name);
        }
    }

    public class Cigarette : Product 
    {
        public Cigarette(int price, string name) : base(price, name)
        {
        }
        public override void Use()
        {
            Console.WriteLine("Du röker upp din" + Name);
        }
    }
}
