using System;

namespace iQuest.VendingMachine.CustomExceptions
{
    internal class InvalidMoneyException : Exception
    {
        private const string DefaultMessage = "Invalid money format";

        public InvalidMoneyException(string message, Exception e)
            : base(DefaultMessage, e)
        {
        }
    }
}