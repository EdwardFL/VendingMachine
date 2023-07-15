using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Model;
using System.Collections.Generic;

namespace iQuest.VendingMachine.DataAccess
{
    internal class ShelfColumnRepository : IShelfColumnRepository
    {

        private static List<ShelfColumn> shelfColumnsList = new List<ShelfColumn>();
        
        public IEnumerable<ShelfColumn> GetAll()
        {
            return shelfColumnsList;
        }

        public ShelfColumn GetById(int id)
        {

            return shelfColumnsList.Find(shelfColumn => shelfColumn.ColumnId == id);
            
        }

        static ShelfColumnRepository()
        {
            shelfColumnsList.Add(new ShelfColumn
            {
                ColumnId = 1,
                Product = new Product
                {
                    Name = "Snikers",
                    Price = 2.99f,
                    Quantity = 1
                }
            });

            shelfColumnsList.Add(new ShelfColumn
            {
                ColumnId = 2,
                Product = new Product
                {
                    Name = "Bounty",
                    Price = 2.99f,
                    Quantity = 25
                }
            });
            shelfColumnsList.Add(new ShelfColumn
            {
                ColumnId = 3,
                Product = new Product
                {
                    Name = "7-Days",
                    Price = 4.99f,
                    Quantity = 25
                }
            });
            shelfColumnsList.Add(new ShelfColumn
            {
                ColumnId = 4,
                Product = new Product
                {
                    Name = "Kinder",
                    Price = 3.99f,
                    Quantity = 20
                }
            });
            shelfColumnsList.Add(new ShelfColumn
            {
                ColumnId = 5,
                Product = new Product
                {
                    Name = "Fanta",
                    Price = 4.99f,
                    Quantity = 30
                }
            });
            shelfColumnsList.Add(new ShelfColumn
            {
                ColumnId = 6,
                Product = new Product
                {
                    Name = "Chio",
                    Price = 5.99f,
                    Quantity = 15
                }
            });
            shelfColumnsList.Add(new ShelfColumn
            {
                ColumnId = 7,
                Product = new Product
                {
                    Name = "Milka",
                    Price = 4.99f,
                    Quantity = 15
                }
            });
        }

    }
}
