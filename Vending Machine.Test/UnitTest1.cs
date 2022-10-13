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
            VendingMachine.poolMoney = 50;
            List<Product> myProduct = VendingMachine.products;
            Assert.True(VendingMachine.poolMoney >= myProduct[0].Price);
        }

        [Fact]
        public void EndTransaction_Test()
        {
            int i = 1;
            VendingMachine.poolMoney = 127;
            Dictionary<int, int> myDictionary = machine.EndTransaction();

            Assert.Equal(100, myDictionary[1]);
            Assert.Equal(20, myDictionary[2]);
            Assert.Equal(5, myDictionary[3]);
            Assert.Equal(1, myDictionary[4]);
            Assert.Equal(1, myDictionary[5]);
        }

        [Fact]
        public void Purchase_Test()
        {

            VendingMachine.poolMoney = 650;
            int lastIndex = VendingMachine.products.Count() - 1;

            int answer = VendingMachine.poolMoney - VendingMachine.products[lastIndex].Price;
            Product myProduct = machine.Purchase(lastIndex);

            Assert.Equal("Kubansk cigarette", myProduct.Name);
            Assert.Equal(answer, VendingMachine.poolMoney);
        }

    }
}
