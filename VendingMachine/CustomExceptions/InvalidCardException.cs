using System;

namespace iQuest.VendingMachine.CustomExceptions
{
    public class InvalidCardException : Exception
    {
        private const string DefaultMessage = "Invalid card format";

        public InvalidCardException()
            : base(DefaultMessage)
        {
        }
    }
}