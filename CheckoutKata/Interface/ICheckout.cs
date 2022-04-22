using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Interface
{
    interface ICheckout
    {
        void Add(string basket);
        IEnumerable<IProduct> Basket { get; }
        decimal TotalAmount { get; }
    }
}
