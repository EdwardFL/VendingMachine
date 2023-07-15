using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.CustomExceptions;
using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly MainView mainView;

        public VendingMachineApplication(List<IUseCase> useCases, MainView mainView)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                try
                {
                    List<IUseCase> availableUseCases = GetExecutableUseCases();

                    IUseCase useCase = mainView.ChooseCommand(availableUseCases);
                    useCase.Execute();
                }
                catch (InvalidColumnException ex)
                {
                    mainView.DisplayInvalidColumnInfo(ex);
                }
                catch (InvalidMoneyException ex)
                {
                    mainView.DisplayWrongFormat(ex);
                }
                catch (InvalidCardException ex)
                {
                    mainView.DisplayWrongCardFormat(ex);
                }
                catch (InsufficientStockException ex)
                {
                    mainView.DisplayInsuficientStockInfo(ex);
                }
                catch (CancelException ex)
                {
                    mainView.DisplayCustomInfo(ex);
                }
                catch (InvalidPasswordException ex)
                {
                    mainView.DisplayWrongPasswordInfo(ex);
                }
                catch (Exception ex)
                {
                    mainView.DisplayUnexpectedExeptionInfo(ex);
                }
            }
        }

        private List<IUseCase> GetExecutableUseCases()
        {
            List<IUseCase> executableUseCases = new List<IUseCase>();

            foreach (IUseCase useCase in useCases)
            {
                if (useCase.CanExecute)
                    executableUseCases.Add(useCase);
            }

            return executableUseCases;
        }
    }
}