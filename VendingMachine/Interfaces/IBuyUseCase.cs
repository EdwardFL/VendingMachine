namespace iQuest.VendingMachine.Interfaces
{
    public interface IBuyUseCase
    {
        string Name { get; }

        string Description { get; }

        bool CanExecute { get; }

        void Execute();
    }
}