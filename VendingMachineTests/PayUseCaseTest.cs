using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace VendingMachineUnitTests
{
    public class PayUseCaseTest
    {
        private Mock<IPayView> payView = new Mock<IPayView>();
        private Mock<List<IPaymentMethod>> paymentMethod = new Mock<List<IPaymentMethod>>();
        private Mock<ICashPaymentView> cashPaymentView = new Mock<ICashPaymentView>();

        [Fact]
        public void HavingPayUseCase_WhenNamePropertyIsPay_ThenCompareItWithExpectedName()
        {
            string actual = "pay";
            PayUseCase payUseCase = new PayUseCase(payView.Object, paymentMethod.Object);

            Assert.Equal(payUseCase.Name, actual);
        }

        [Fact]
        public void HavingPayUseCase_WhenPayViewIsNull_ThenTrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new PayUseCase(null, paymentMethod.Object));
        }

        [Fact]
        public void HavingPayUseCase_WhenPaymentMethodIsNull_ThenTrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new PayUseCase(payView.Object, null));
        }

        //[Fact]
        //public void HavingPayUseCase()
        //{
        //    CashPaymentMethod cashPaymentMethod = new CashPaymentMethod(cashPaymentView.Object);
        //    List<IPaymentMethod> paymentMethods = new List<IPaymentMethod>();

        //    PayUseCase payUseCase = new PayUseCase(payView.Object, paymentMethod.Object);
        //}
    }
}