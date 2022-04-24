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
        private readonly IEnumerable<IProduct> _products;
        private readonly IEnumerable<IDiscount> _discounts;

        private List<IProduct> _basket;

        public Checkout(IEnumerable<IProduct> products, IEnumerable<IDiscount> discounts = null)
        {
            _products = products;
            _discounts = discounts;

            _basket = new List<IProduct>();
        }

        public void Add(string basket)
        {
            var items = basket.ToCharArray();

            foreach (var item in items)
            {
                var product = _products.FirstOrDefault(x => x.SKU == item);

                if (product == null)
                    throw new InvalidOperationException("Product not found");

                _basket.Add(product);
            }
        }

        public IEnumerable<IProduct> Basket => _basket;

        public decimal TotalAmount
        {
            get
            {
                var groupedItems = _basket.GroupBy(x => x.SKU).Select(x => new { SKU = x.Key, Quantity = x.Count() });
                decimal total = 0;

                foreach (var group in groupedItems)
                {
                    var item = _products.Single(x => x.SKU == group.SKU);
                    var discount = _discounts.FirstOrDefault(x => x.SKU == group.SKU);

                    if (discount != null)
                    {
                        if (discount.DiscountType == DiscountType.MultibuyPrice)
                            total += GetMultibuy_FixedPrice(item.UnitPrice, group.Quantity, discount);
                        else if (discount.DiscountType == DiscountType.MultibuyPercentage)
                            total += GetMultibuy_PercentageDiscount(item.UnitPrice, group.Quantity, discount);
                    }
                    else
                    {
                        total += item.UnitPrice * group.Quantity;
                    }
                }

                return total;
            }
        }

        public decimal GetMultibuy_FixedPrice(decimal unitPrice, int quantity, IDiscount discount)
        {
            int multibuys = quantity / discount.QuantityForDiscount;
            int remainder = quantity % discount.QuantityForDiscount;

            var total = (multibuys * discount.DiscountPriceForGroup) + (unitPrice * remainder);

            return total;
        }

        public decimal GetMultibuy_PercentageDiscount(decimal unitPrice, int quantity, IDiscount discount)
        {
            int remainder = quantity % discount.QuantityForDiscount;

            var discountUnitPrice = (unitPrice / 100) * (100 - discount.DiscountPercentagePerItem);

            var total = ((quantity - remainder) * discountUnitPrice) + (unitPrice * remainder);

            return total;
        }

    }
}
