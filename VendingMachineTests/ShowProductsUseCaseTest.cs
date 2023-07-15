using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Model;
using iQuest.VendingMachine.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace VendingMachineUnitTests
{
    public class ShowProductsUseCaseTest
    {
        private readonly Mock<IShowProductsView> showProductsView = new Mock<IShowProductsView>();
        private readonly Mock<IShelfColumnRepository> shelfColumnRepository = new Mock<IShelfColumnRepository>();

        [Fact]
        public void HavingShowProductsUseCase_WhenNameIsProducts_ThenCompareItWithExpectedName()
        {
            string actual = "products";
            ShowProductsUseCase showProductsUseCase = new ShowProductsUseCase(shelfColumnRepository.Object, showProductsView.Object);

            Assert.Equal(showProductsUseCase.Name, actual);
        }

        [Fact]
        public void HavingShowProductsUseCase_WhenDescriptionIsSet_ThenCompareItWithExpectedDescription()
        {
            string actual = "View all products";
            ShowProductsUseCase showProductsUseCase = new ShowProductsUseCase(shelfColumnRepository.Object, showProductsView.Object);

            Assert.Equal(showProductsUseCase.Description, actual);
        }

        [Fact]
        public void HavingShowProductsUseCase_WhenCanExecuteIsSet_ThenCompareItWithExpectedCanExecute()
        {
            bool actual = true;
            ShowProductsUseCase showProductsUseCase = new ShowProductsUseCase(shelfColumnRepository.Object, showProductsView.Object);

            Assert.Equal(showProductsUseCase.CanExecute, actual);
        }

        [Fact]
        public void HavingShowProductsUseCase_WhenShelfColumnRepositoryIsNull_ThenTrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new ShowProductsUseCase(null, showProductsView.Object));
        }

        [Fact]
        public void HavingShowProductsUseCase_WhenShowProductsViewIsNull_ThenTrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new ShowProductsUseCase(shelfColumnRepository.Object, null));
        }

        [Fact]
        public void HavingShowProductsUseCase_WhenExecuteMethodIsCalled_ThenGetAllMethodIsCalled()
        {
            ShowProductsUseCase showProductsUseCase = new ShowProductsUseCase(shelfColumnRepository.Object, showProductsView.Object);

            showProductsUseCase.Execute();

            shelfColumnRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public void HavingShowProductsUseCase_WhenExecduteMethodIsCalled_ThenGetAllMethodIsCalled()
        {
            IEnumerable<ShelfColumn> shelfColumnsList = new List<ShelfColumn>();
            ShowProductsUseCase showProductsUseCase = new ShowProductsUseCase(shelfColumnRepository.Object, showProductsView.Object);

            showProductsUseCase.Execute();

            showProductsView.Verify(x => x.DisplayProducts(shelfColumnsList), Times.Once);
        }
    }
}