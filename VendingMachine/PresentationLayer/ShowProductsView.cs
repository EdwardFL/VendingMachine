using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Model;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ShowProductsView : IShowProductsView
    {
        public void DisplayProducts(IEnumerable<ShelfColumn> products)
        {
            DisplayDetails();   
            foreach (var product in products)
            {
                Console.WriteLine("================================================");
                Console.WriteLine(product.ColumnId + "\t" + product.Product.Name + "\t\t" + product.Product.Price + "\t\t  " + product.Product.Quantity);
            }
        }

        public void DisplayDetails()
        {
           Console.WriteLine("Id " + " \tName " + " \t\tPrice" + "\t\tQuantity");
        }
    }
}
