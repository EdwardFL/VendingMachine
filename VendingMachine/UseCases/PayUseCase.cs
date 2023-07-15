using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.UseCases
{
    internal class PayUseCase : IPaymentMethod
    {
        private readonly IPayView payView;
        private readonly List<IPaymentMethod> paymentMethod;

        public string Name => "pay";

        public PayUseCase(IPayView payView, List<IPaymentMethod> paymentMethod)
        {
            this.payView = payView ?? throw new ArgumentNullException(nameof(payView));
            this.paymentMethod = paymentMethod ?? throw new ArgumentNullException(nameof(paymentMethod));
        }

        public void Execute(float money)
        {
            var userPaymentMethod = payView.AskPaymentMethod(paymentMethod);
            userPaymentMethod.Execute(money);
            payView.AnnounceSuccessfulPayment();
        }
    }
}