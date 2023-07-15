namespace iQuest.VendingMachine.Interfaces
{
    public interface ICashPaymentView
    {
        public float CollectMoneyCash();

        public void ReturnChange(float money);
    }
}