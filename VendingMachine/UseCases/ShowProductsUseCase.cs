using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class ShowProductsUseCase : IUseCase
    {
        private readonly IShowProductsView showProductsView;
        private readonly IShelfColumnRepository shelfColumnRepository;

        public string Name => "products";

        public string Description => "View all products";

        public bool CanExecute => true;

        public ShowProductsUseCase(IShelfColumnRepository shelfColumnRepository, IShowProductsView showProductsView)
        {
            this.shelfColumnRepository = shelfColumnRepository ?? throw new ArgumentNullException(nameof(shelfColumnRepository));
            this.showProductsView = showProductsView ?? throw new ArgumentNullException(nameof(showProductsView));
        }

        public void Execute()
        {
            var products = shelfColumnRepository.GetAll();
            showProductsView.DisplayProducts(products);
        }
    }
}
