namespace Vending_Machine
{
    public abstract class Product
    {
        public int Price { get; set; }
        public string Name { get; set; }

        public Product(int price, string name)
        {
            Price = price;
            Name = name;
        }

        public void Examine()
        {
            Console.WriteLine($"Produkten heter {Name} och kostar {Price}kr");
        }

        public abstract void Use();
    }
}
