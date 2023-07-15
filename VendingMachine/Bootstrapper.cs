using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PaymentMethod;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using System.Collections.Generic;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            MainView mainView = new MainView();
            LoginView loginView = new LoginView();

            AuthenticationService authenticationService = new AuthenticationService();
            ShelfColumnRepository shelfColumnRepository = new ShelfColumnRepository();
            ShowProductsView showProductsView = new ShowProductsView();
            BuyView buyView = new BuyView();
            PayView payView = new PayView();
            
            CashPaymentView cashPaymentView = new CashPaymentView();
            CardPaymentView cardPaymentView = new CardPaymentView();

            List<IPaymentMethod> payUseCaseMethod = new List<IPaymentMethod>
            {
                new CashPaymentMethod(cashPaymentView),
                new CardPaymentMethod(cardPaymentView)
            };
            PayUseCase payUseCase = new PayUseCase(payView, payUseCaseMethod);

            List<IUseCase> useCases = new List<IUseCase>
            {
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                new ShowProductsUseCase(shelfColumnRepository, showProductsView),
                new BuyUseCase(shelfColumnRepository, buyView, authenticationService, payUseCase)
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}