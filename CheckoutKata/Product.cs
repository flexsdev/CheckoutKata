using CheckoutKata.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Product : IProduct
    {
        public char SKU { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
