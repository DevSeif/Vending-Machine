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




    }
}