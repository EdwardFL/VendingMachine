using iQuest.VendingMachine.CustomExceptions;
using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentView : DisplayBase, ICashPaymentView
    {
        public float CollectMoneyCash()
        {
            DisplayLine("\nPlease insert the amount of money: ", ConsoleColor.Cyan);
            string userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                throw new CancelException();
            }
            try
            {
                float money = Convert.ToSingle(userInput);
                return money;
            }
            catch (FormatException e)
            {
                throw new InvalidMoneyException(userInput, e);
            }
        }

        public void ReturnChange(float money)
        {
            Display("\nChange: ", ConsoleColor.Cyan);
            DisplayLine("" + money, ConsoleColor.White);
        }
    }
}