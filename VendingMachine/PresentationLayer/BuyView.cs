using iQuest.VendingMachine.CustomExceptions;
using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView 
    {

        public int RequestColumn()
        {
            Display("Please enter product's ID: ", ConsoleColor.Cyan);

            int columnID;
            var userInput = Console.ReadLine();

            while (!int.TryParse(userInput, out columnID))
            {

                if (string.IsNullOrEmpty(userInput))
                    throw new CancelException();

                Display("Please enter a valid number: ", ConsoleColor.Red);
                userInput = Console.ReadLine();

            }

            return columnID;
        }

        public void DispenseProduct(string productName)
        {
            Display("\nFollowing product was dispensed: ", ConsoleColor.Cyan);
            DisplayLine(productName, ConsoleColor.White);
        }
    }
}
