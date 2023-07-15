using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class PayView : DisplayBase, IPayView
    {
        public IPaymentMethod AskPaymentMethod(List<IPaymentMethod> paymentMethods)
        {
            DisplayLine("\nIn order to buy a product, you need to select the payment method from the following: ", ConsoleColor.Cyan);
            DisplayLine("cash", ConsoleColor.White);
            DisplayLine("card", ConsoleColor.White);
            DisplayLine("\nPlease chose a payment method: ", ConsoleColor.Cyan);
            var userInput = Console.ReadLine();
            IPaymentMethod selectedMethod = null;
            foreach (var paymentMethod in paymentMethods)
            {
                if (paymentMethod.Name.Equals(userInput))
                {
                    selectedMethod = paymentMethod;
                }
            }
            return selectedMethod;
        }

        public void AnnounceSuccessfulPayment()
        {
            DisplayLine("\nThe payment was successfully made!", ConsoleColor.Green);
        }
    }
}