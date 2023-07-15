using iQuest.VendingMachine.Model;
using System.Collections.Generic;

namespace iQuest.VendingMachine.Interfaces
{
    public interface IShowProductsView
    {
        public void DisplayProducts(IEnumerable<ShelfColumn> products);

        public void DisplayDetails();
    }
}