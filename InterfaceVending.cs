namespace Vending_Machine
{
    public interface IVending
    {
        Product Purchase(int argIndex);

        void ShowAll();

        void InsertMoney(int money);

        Dictionary<int, int> EndTransaction();
    }
}
