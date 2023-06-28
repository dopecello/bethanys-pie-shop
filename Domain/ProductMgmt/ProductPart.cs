using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryMgmt
{ //added private methods into this class to clean up the code.
    public partial class Product
    {
        private void Log(string message)
        {
            //this could be written to a file
            Console.WriteLine(message);
        }

        private string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }

        private void UpdateLowStock()
        {
            if (AmountInStock < 10) //for now, a fixed value.
            {
                IsBelowStockThreshold = true;
            }
        }

        private void DecreaseStock(int items, string reason)
        {
            if (items <= AmountInStock)
            {
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }

            UpdateLowStock();

            Log(reason);
        }
    }
}
