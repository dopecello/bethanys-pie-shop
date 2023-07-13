using PieShop.InventoryMgmt.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryMgmt.Domain.ProductMgmt
{
    internal class BulkProduct : Product
    {
        public BulkProduct(int id, string name, string? description, Price price, int maxAmountInStock) : base(id, name, description, price, UnitType.PerKg, maxAmountInStock)
        {
        }
    }
}
