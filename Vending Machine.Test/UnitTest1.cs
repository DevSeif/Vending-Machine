namespace Vending_Machine.Test
{
    public class UnitTest1
    {

        VendingMachine machine = new VendingMachine();

        [Fact]
        public void CorrectInput_Test()
        {
            Assert.True(machine.CheckInput(20));
            Assert.False(machine.CheckInput(21));
        }

        [Fact]
        public void EnoughMoney_Test()
        {
            int poolMoney = 50;
            List<Product> products = new List<Product>
        {
            new Snack(12, "Snickers"),

        };
            Assert.True(poolMoney >= products[0].Price);
        }

        [Fact]
        public void EndTransaction_Test()
        {
            int i = 1;
            int poolMoney = 127;
            int[] moneyDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();

            foreach (int e in moneyDenominations.Reverse())
            {
                while (e <= poolMoney)
                {
                    myDictionary.Add(i, e);
                    i++;
                    poolMoney -= e;
                }
            }

            Assert.Equal(100, myDictionary[1]);
            Assert.Equal(20, myDictionary[2]);
            Assert.Equal(5, myDictionary[3]);
            Assert.Equal(1, myDictionary[4]);
            Assert.Equal(1, myDictionary[5]);
        }

        [Fact]
        public void Purchase_Test()
        {
            List<Product> products = new List<Product>();
            products.Add(new Snack(12, "Snickers"));
            int argIndex = 0;
            int poolMoney = 15;
            int answer = poolMoney - products[argIndex].Price;

            Product product = products[argIndex];
            poolMoney -= products[argIndex].Price;
            products.RemoveAt(argIndex);

            Assert.Empty(products);
            Assert.Equal(answer, poolMoney);

        }






    }
}