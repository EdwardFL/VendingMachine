using System.Collections.Generic;

namespace iQuest.VendingMachine.Interfaces
{
    public interface IPayView
    {
        public IPaymentMethod AskPaymentMethod(List<IPaymentMethod> paymentMethods);

        public void AnnounceSuccessfulPayment();
    }
}