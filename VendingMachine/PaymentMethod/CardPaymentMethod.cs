using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine.PaymentMethod
{
    internal class CardPaymentMethod : IPaymentMethod
    {
        private readonly ICardPaymentView cardPaymentView;
        public string Name => "card";

        public CardPaymentMethod(ICardPaymentView cardPaymentView)
        {
            this.cardPaymentView = cardPaymentView ?? throw new ArgumentNullException(nameof(cardPaymentView));
        }

        public void Execute(float nr)
        {
            cardPaymentView.AskCardNumber();
        }
    }
}