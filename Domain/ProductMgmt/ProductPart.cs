using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryMgmt
{ //added private methods into this class to clean up the code.
    public partial class Product
    {
        public static int StockThreshold = 5;

        public static void ChangeStockThreshold(int newStockThreshold)
        {
            // we will only allow this to go through if the value is > 0
            if (newStockThreshold > 0)
                StockThreshold = newStockThreshold;
        }

        protected void Log(string message)
        {
            //this could be written to a file
            Console.WriteLine(message);
        }

        protected string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }

        public void UpdateLowStock()
        {
            if (AmountInStock < StockThreshold) //for now, a fixed value.
            {
                IsBelowStockThreshold = true;
            }
        }
    }
}
