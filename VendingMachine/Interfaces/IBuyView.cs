namespace iQuest.VendingMachine.Interfaces
{
    public interface IBuyView
    {
        public int RequestColumn();
        public void DispenseProduct(string productName);
    }
}
