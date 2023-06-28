using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryMgmt.Domain.General
{
    public class Price
    {
        public double ItemPrice { get; set; }
        public Currency Currency { get; set; }
        public override string ToString()
        {
            return $"{ItemPrice} {Currency}"; //now when we call ToString() on Price, it will exhibit this behavior because of the override keyword.
        }

        public Price(double price, Currency currency)
        {
            ItemPrice = price;
            Currency = currency;
        }
    }


}
