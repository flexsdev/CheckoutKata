using System;

namespace CheckoutKata.Interface
{
    public interface IProduct
    {
        char SKU { get; set; }
        decimal UnitPrice { get; set; }
    }
}
