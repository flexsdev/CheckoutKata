using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Interface
{
    public interface IDiscount
    {
        char SKU { get; set; }
        DiscountType DiscountType { get; set; }
        int QuantityForDiscount { get; set; }
        decimal DiscountPriceForGroup { get; set; }
        decimal DiscountPercentagePerItem { get; set; }
    }

    public enum DiscountType
    {
        MultibuyPrice,
        MultibuyPercentage
    }
}
