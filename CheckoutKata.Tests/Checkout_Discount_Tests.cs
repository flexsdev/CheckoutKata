using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckoutKata.Tests
{
    public class Checkout_Discount_Tests
    {
        private IEnumerable<Product> _products;
        private IEnumerable<Discount> _discounts;

        public Checkout_Discount_Tests()
        {
            _products = new[]
            {
                new Product() { SKU = 'A', UnitPrice = 10 },
                new Product() { SKU = 'B', UnitPrice = 15 },
                new Product() { SKU = 'C', UnitPrice = 40 },
                new Product() { SKU = 'D', UnitPrice = 55 }
            };

            _discounts = new[]
            {
                new Discount() {SKU = 'B', DiscountType = Interface.DiscountType.MultibuyPrice, QuantityForDiscount = 3, DiscountPriceForGroup = 40 },
                new Discount() {SKU = 'D', DiscountType = Interface.DiscountType.MultibuyPercentage, QuantityForDiscount = 2, DiscountPercentagePerItem = 25 },
            };
        }

        [Fact]
        public void Checkout_MultibuyItemQuantityDoesNotQualifyForDiscount_CalculatesCorrectTotal()
        {
            //Arrange
            var checkout = new Checkout(_products, _discounts);

            //Act
            checkout.Add("B");

            //Assert
            Assert.Equal(15, checkout.TotalAmount);
        }

        [Fact]
        public void Checkout_MultibuyItemQuantityMeetsCriteriaForDiscount_CalculatesCorrectTotal()
        {
            //Arrange
            var checkout = new Checkout(_products, _discounts);

            //Act
            checkout.Add("BBB");

            //Assert
            Assert.Equal(40, checkout.TotalAmount);
        }

        [Fact]
        public void Checkout_MultibuyWherePartQualifies_CalculatesCorrectTotal()
        {
            //Arrange
            var checkout = new Checkout(_products, _discounts);

            //Act
            checkout.Add("BBBB");

            //Assert
            Assert.Equal(55, checkout.TotalAmount);
        }

        [Fact]
        public void Checkout_MultibuyDiscountPercentage_CalculatesCorrectTotal()
        {
            //Arrange
            var checkout = new Checkout(_products, _discounts);

            //Act
            checkout.Add("DD");

            //Assert
            Assert.Equal(82.50M, checkout.TotalAmount);
        }

        [Theory]
        [InlineData("A", 10)]
        [InlineData("BB", 30)]
        [InlineData("BBBBBB", 80)]
        [InlineData("ABCD", 120)]
        [InlineData("ABBCD", 135)]
        [InlineData("ABBBCD", 145)]
        [InlineData("ABBBCDD", 172.50)]
        public void Checkout_CheckingVariousCombinations_CalculatesCorrectTotal(string basket, decimal expectedTotal)
        {
            //Arrange
            var checkout = new Checkout(_products, _discounts);

            //Act
            checkout.Add(basket);

            //Assert
            Assert.Equal(expectedTotal, checkout.TotalAmount);
        }

    }
}
