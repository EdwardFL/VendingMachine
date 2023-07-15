using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine.PaymentMethod
{
    internal class CashPaymentMethod : IPaymentMethod
    {
        private readonly ICashPaymentView cashPaymentView;
        public string Name => "cash";

        public CashPaymentMethod(ICashPaymentView cashPaymentView)
        {
            this.cashPaymentView = cashPaymentView ?? throw new ArgumentNullException(nameof(cashPaymentView));
        }

        public void Execute(float initialPrice)
        {
            float userMoney = 0.0f;
            while (userMoney < initialPrice)
            {
                userMoney += cashPaymentView.CollectMoneyCash();
            }

            if (userMoney > initialPrice)
            {
                var change = userMoney - initialPrice;
                cashPaymentView.ReturnChange(change);
            }
        }
    }
}