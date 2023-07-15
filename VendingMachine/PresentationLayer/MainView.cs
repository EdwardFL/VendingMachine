using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class MainView : DisplayBase
    {
        public void DisplayApplicationHeader()
        {
            ApplicationHeaderControl applicationHeaderControl = new ApplicationHeaderControl();
            applicationHeaderControl.Display();
        }

        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases)
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl
            {
                UseCases = useCases
            };
            return commandSelectorControl.Display();
        }

        public void DisplayCustomInfo(Exception ex)
        {
            Display("A problem occurred during execution, please try again. ", ConsoleColor.Red);
        }

        public void DisplayInsuficientStockInfo(Exception ex)
        {
            Display("Insufficient stock! Please choose another product. ", ConsoleColor.Red);
        }

        public void DisplayInvalidColumnInfo(Exception ex)
        {
            Display("Invaid column! Please try again. ", ConsoleColor.Red);
        }

        public void DisplayWrongPasswordInfo(Exception ex)
        {
            Display("Wrong password! Please try again. ", ConsoleColor.Red);
        }

        public void DisplayUnexpectedExeptionInfo(Exception ex)
        {
            Display("An unexpected error occured during program execution, please try again. ", ConsoleColor.Red);
        }

        internal void DisplayWrongCardFormat(Exception ex)
        {
            Display("Invalid card format! Please try again.", ConsoleColor.Red);
        }

        public void DisplayWrongFormat(Exception ex)
        {
            Display("Invalid money format! Please try again.", ConsoleColor.Red);
        }
    }
}