using PieShop.InventoryMgmt.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryMgmt.Domain.ProductMgmt
{
    internal class BoxedProduct : Product
    {
        private int amountPerBox;

        public int AmountPerBox
        {
            get { return amountPerBox; }
            set
            {
                amountPerBox = value;
            }
        }
        public BoxedProduct(int id, string name, string? description, Price price, int maxAmountInStock, int amountPerBox) : base(id, name, description, price, UnitType.PerBox, maxAmountInStock)
        {
            AmountPerBox = amountPerBox;
        }

        public string DisplayBoxedProductDetails()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Boxed product\n");
            sb.Append($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockThreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();
        }

        public override void UseProduct(int items)
        {
            int smallestMultiple = 0;
            int batchSize;

            while (true)
            {
                smallestMultiple++;
                if (smallestMultiple * amountPerBox > items)
                {
                    batchSize = smallestMultiple * amountPerBox;
                    break;
                }
            }
            base.UseProduct(batchSize); //use base method.
        }

        public override void IncreaseStock()
        {
            int newStock = 1;

            if (IsBelowStockThreshold)
            {
                IncreaseStock(newStock);
            }
        }

        public override void IncreaseStock(int amount)
        {
            int newStock = AmountInStock + amount * amountPerBox;

            if (newStock <= maxItemsInStock)
            {
                AmountInStock += amount;
            }
            else
            {
                AmountInStock = maxItemsInStock; //only store the possible items, overstock isn't stored.
                Log($"{CreateSimpleProductRepresentation} stock overflow. {newStock - AmountInStock} item(s) ordered that couldn't be stored.");
            }
            if (AmountInStock > StockThreshold)
            {
                IsBelowStockThreshold = false;
            }
        }

        public override string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Boxed Product\n");
            sb.Append($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock.");

            if (IsBelowStockThreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();
        }
    }
}
