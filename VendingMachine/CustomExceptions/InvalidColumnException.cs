using System;

namespace iQuest.VendingMachine.CustomExceptions
{
    public class InvalidColumnException : Exception
    {
        private const string DefaultMessage = "Invalid column";

        public InvalidColumnException()
            : base(DefaultMessage)
        {
        }
    }
}