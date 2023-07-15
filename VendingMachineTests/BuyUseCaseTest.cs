using iQuest.VendingMachine.CustomExceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Model;
using iQuest.VendingMachine.UseCases;
using Moq;
using System;
using Xunit;

namespace VendingMachineTests
{
    public class BuyUseCaseTest
    {
        private Mock<IBuyView> buyView = new Mock<IBuyView>();
        private Mock<IAuthenticationService> authenticationService = new Mock<IAuthenticationService>();
        private Mock<IShelfColumnRepository> shelfColumnRepository = new Mock<IShelfColumnRepository>();
        private Mock<IPaymentMethod> payUseCase = new Mock<IPaymentMethod>();

        [Fact]
        public void HavingABuyUseCase_WhenColumnIsInvalid_ThrowsInvalidColumnException()
        {
            var columnId = buyView.Setup(x => x.RequestColumn())
            .Returns(null);
            BuyUseCase buyUseCase = new BuyUseCase(shelfColumnRepository.Object, buyView.Object, authenticationService.Object, payUseCase.Object);

            Assert.Throws<InvalidColumnException>(() =>
            {
                buyUseCase.Execute();
            });
        }

        [Fact]
        public void HavingABuyUseCase_WhenStockIsInsufficient_ThrowsInsufficientStockException()
        {
            ShelfColumn shelfColumn = new ShelfColumn
            {
                ColumnId = 1,
                Product = new Product
                {
                    Name = "Kinder",
                    Price = 2.2f,
                    Quantity = 0
                }
            };
            var columnId = buyView.Setup(x => x.RequestColumn())
            .Returns(1);
            var returnedShelfColumn = shelfColumnRepository.Setup(x => x.GetById(1)).Returns(shelfColumn);
            BuyUseCase buyUseCase = new BuyUseCase(shelfColumnRepository.Object, buyView.Object, authenticationService.Object, payUseCase.Object);

            Assert.Throws<InsufficientStockException>(() =>
           {
               buyUseCase.Execute();
           });
        }

        [Fact]
        public void HavingABuyUseCase_WhenUserIsUnauthenticated_ThenCanExecuteReturnsTrue()
        {
            authenticationService.Setup(x => x.IsUserAuthenticated).Returns(false);
            BuyUseCase buyUseCase = new BuyUseCase(shelfColumnRepository.Object, buyView.Object, authenticationService.Object, payUseCase.Object);

            Assert.True(buyUseCase.CanExecute);
        }

        [Fact]
        public void HavingBuyUseCase_WhenNamePropertyIsBuy_ThenCompareItWithExpectedName()
        {
            string actual = "buy";
            BuyUseCase buyUseCase = new BuyUseCase(shelfColumnRepository.Object, buyView.Object, authenticationService.Object, payUseCase.Object);

            Assert.Equal(buyUseCase.Name, actual);
        }

        [Fact]
        public void HavingABuyUseCase_WhenDescriptionIsSet_ThenCompareItWithExpectedDescription()
        {
            string actual = "Buy a product";
            BuyUseCase buyUseCase = new BuyUseCase(shelfColumnRepository.Object, buyView.Object, authenticationService.Object, payUseCase.Object);

            Assert.Equal(buyUseCase.Description, actual);
        }

        [Fact]
        public void HavingABuyUseCase_WhenQuantityDecrease_ThenReturnsQuantity()
        {
            ShelfColumn shelfColumn = new ShelfColumn
            {
                ColumnId = 1,
                Product = new Product
                {
                    Name = "Kinder",
                    Price = 2.2f,
                    Quantity = 20
                }
            };
            var columnId = buyView.Setup(x => x.RequestColumn()).Returns(1);
            var returnedShelfColumn = shelfColumnRepository.Setup(x => x.GetById(1)).Returns(shelfColumn);
            BuyUseCase buyUseCase = new BuyUseCase(shelfColumnRepository.Object, buyView.Object, authenticationService.Object, payUseCase.Object);

            buyUseCase.Execute();

            Assert.Equal(19, shelfColumn.Product.Quantity);
        }

        [Fact]
        public void HavingABuyUseCase_WhenExecuteMethodIsCalled_ThenVerifyIfDispenseProductIsCalled()
        {
            ShelfColumn shelfColumn = new ShelfColumn
            {
                ColumnId = 1,
                Product = new Product
                {
                    Name = "Kinder",
                    Price = 2.2f,
                    Quantity = 19
                }
            };
            var columnId = buyView.Setup(x => x.RequestColumn()).Returns(1);
            var returnedShelfColumn = shelfColumnRepository.Setup(x => x.GetById(1)).Returns(shelfColumn);
            BuyUseCase buyUseCase = new BuyUseCase(shelfColumnRepository.Object, buyView.Object, authenticationService.Object, payUseCase.Object);

            buyUseCase.Execute();

            buyView.Verify(x => x.DispenseProduct(shelfColumn.Product.Name), Times.Once);
        }

        [Fact]
        public void HavingBuyUseCase_WhenShelfColumnRepositoryIsNull_ThenTrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new BuyUseCase(null, buyView.Object, authenticationService.Object, payUseCase.Object));
        }

        [Fact]
        public void HavingBuyUseCase_WhenBuyViewIsNull_ThenTrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new BuyUseCase(shelfColumnRepository.Object, null, authenticationService.Object, payUseCase.Object));
        }

        [Fact]
        public void HavingBuyUseCase_WhenAuthenticationServiceIsNull_ThenTrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new BuyUseCase(shelfColumnRepository.Object, buyView.Object, null, payUseCase.Object));
        }

        [Fact]
        public void HavingBuyUseCase_WhenPayUseCaseIsNull_ThenTrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new BuyUseCase(shelfColumnRepository.Object, buyView.Object, authenticationService.Object, null));
        }
    }
}