namespace Vending_Machine
{
    public interface IVending
    {
        public Product Purchase(int argIndex);

        public void ShowAll();

        public void InsertMoney(int money);

        public Dictionary<int, int> EndTransaction();
    }
}
