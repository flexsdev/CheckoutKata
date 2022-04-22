using CheckoutKata.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private readonly IEnumerable<Product> _products;

        private List<Product> _basket;

        public Checkout(IEnumerable<Product> products)
        {
            _products = products;

            _basket = new List<Product>();
        }

        public void Add(string basket)
        {
            var items = basket.ToCharArray();

            foreach (var item in items)
            {
                var product = _products.FirstOrDefault(x => x.SKU == item);

                if (product != null)
                    _basket.Add(product);
            }
        }

        public IEnumerable<IProduct> Basket => _basket;

        public decimal TotalAmount => _basket.Sum(x => x.UnitPrice);

    }
}
