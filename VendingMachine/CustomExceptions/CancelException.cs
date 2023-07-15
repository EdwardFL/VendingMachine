using System;

namespace iQuest.VendingMachine.CustomExceptions
{
    public class CancelException : Exception
    {
        private const string DefaultMessage = "A problem occurred during execution.";

        public CancelException()
            : base(DefaultMessage)
        {
        }
    }
}