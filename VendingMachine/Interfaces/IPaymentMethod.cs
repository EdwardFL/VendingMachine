namespace iQuest.VendingMachine.Interfaces
{
    public interface IPaymentMethod
    {
        string Name { get; }

        void Execute(float initialPrice);
    }
}