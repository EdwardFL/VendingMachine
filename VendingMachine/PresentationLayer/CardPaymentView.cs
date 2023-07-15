using iQuest.VendingMachine.CustomExceptions;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Linq;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CardPaymentView : DisplayBase, ICardPaymentView
    {
        public string AskCardNumber()
        {
            Display("Please enter the card number: ", ConsoleColor.Cyan);
            var userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                throw new CancelException();
            }
            if (Luhn(userInput) == false)
            {
                throw new InvalidCardException();
            }
            return userInput;
        }

        private bool Luhn(string card)
        {
            return card.All(char.IsDigit) && card.Reverse()
             .Select(c => c - 48)
             .Select((thisNum, i) => i % 2 == 0
                 ? thisNum
                 : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
             ).Sum() % 10 == 0;
        }
    }
}