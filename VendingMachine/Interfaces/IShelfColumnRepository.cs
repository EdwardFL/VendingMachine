using iQuest.VendingMachine.Model;
using System.Collections.Generic;

namespace iQuest.VendingMachine.Interfaces
{
    public interface IShelfColumnRepository
    {
        public IEnumerable<ShelfColumn> GetAll();
        public ShelfColumn GetById(int id);
    }
}
