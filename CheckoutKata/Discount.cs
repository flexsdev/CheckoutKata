using CheckoutKata.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Discount : IDiscount
    {
        public char SKU { get; set; }
        public DiscountType DiscountType { get; set; }
        public int QuantityForDiscount { get; set; }
        public decimal DiscountPriceForGroup { get; set; }
        public decimal DiscountPercentagePerItem { get; set; }
    }
}
