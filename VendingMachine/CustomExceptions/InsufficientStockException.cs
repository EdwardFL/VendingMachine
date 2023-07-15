using System;

namespace iQuest.VendingMachine.CustomExceptions
{
    public class InsufficientStockException : Exception
    {
        private const string DefaultMessage = "Insufficient stock for the selected product";

        public InsufficientStockException()
            : base(DefaultMessage)
        {
        }
    }
}