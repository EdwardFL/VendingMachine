using iQuest.VendingMachine.CustomExceptions;
using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IBuyView buyView;
        private readonly IShelfColumnRepository shelfColumnRepository;
        private readonly IAuthenticationService authenticationService;
        private readonly IPaymentMethod payUseCase;

        public string Name => "buy";

        public string Description => "Buy a product";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyUseCase(IShelfColumnRepository shelfColumnRepository, IBuyView buyView, IAuthenticationService authenticationService, IPaymentMethod payUseCase)
        {
            this.shelfColumnRepository = shelfColumnRepository ?? throw new ArgumentNullException(nameof(shelfColumnRepository));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.payUseCase = payUseCase ?? throw new ArgumentNullException(nameof(payUseCase));
        }

        public void Execute()
        {
            var columnId = buyView.RequestColumn();
            var shelfColumn = shelfColumnRepository.GetById(columnId);

            if (shelfColumn == null)
                throw new InvalidColumnException();

            if (shelfColumn.Product.Quantity < 1)
                throw new InsufficientStockException();

            payUseCase.Execute(shelfColumn.Product.Price);

            shelfColumn.Product.Quantity--;

            buyView.DispenseProduct(shelfColumn.Product.Name);
        }
    }
}