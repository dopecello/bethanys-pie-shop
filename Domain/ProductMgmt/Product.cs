using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieShop.InventoryMgmt.Domain.General;
using PieShop.InventoryMgmt.Domain.ProductMgmt;

namespace PieShop.InventoryMgmt
{
    public partial class Product
    {
        private int id;
        private string name = string.Empty;
        private string? description;

        protected int maxItemsInStock = 0;



        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value.Length > 50 ? value[..50] : value; // the [..50] dots indicate a range operator. It will register all chars up to 50.
            }
        }

        public string? Description
        {
            get { return description; }
            set
            {
                if (value == null)
                {
                    description = string.Empty;
                }
                else
                {
                    description = value.Length > 250 ? value[..250] : value;
                }
            }
        }

        public UnitType UnitType { get; set; }
        public int AmountInStock { get; protected set; } // this value is avail for use inside the class and inheriting classes only.
        public bool IsBelowStockThreshold { get; protected set; }

        public Price Price { get; set; }

        public Product(int id) : this(id, string.Empty)
        {
        }

        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Product(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            UnitType = unitType;

            maxItemsInStock = maxAmountInStock;

            if (AmountInStock < 10)
            {
                IsBelowStockThreshold = true;
            }
        }

        //public product(int id)
        //{
        //    id = id;
        //} <=== having duplicate code is a bad practice

        //public Product()
        //{ } //default contructor: used to initialize an object

        public virtual void UseProduct(int items)
        {
            if (items <= AmountInStock)
            { //use the items
                AmountInStock -= items;
                UpdateLowStock();
                Log($"Amount in stock updated. Now {AmountInStock} items in stock.");
            }
            else
            {
                Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}. {AmountInStock} available but {items} requested.");
            }
        }

        public virtual void IncreaseStock()
        {
            AmountInStock++;
        }

        public virtual void IncreaseStock(int amount) //this is a method overloading because this method, although the same, accepts one param, while the previous one doesn't accept any.
        {
            int newStock = AmountInStock + amount;

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

        protected virtual void DecreaseStock(int items, string reason)
        {
            if (items <= AmountInStock)
            {
                // decrease stock with the specified amount of items
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }
            UpdateLowStock();
            Log(reason);
        }

        public virtual string DisplayDetailsShort()
        {
            return $"{id}. {name} \n{description}\n{AmountInStock} items(s) in stock.";
        }

        public virtual string DisplayDetailsFull()
        {
            return DisplayDetailsFull("");
        }

        public virtual string DisplayDetailsFull(string extraDetails)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock.");
            sb.Append(extraDetails);
            if (IsBelowStockThreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }
            return sb.ToString();
        }
    }
}

