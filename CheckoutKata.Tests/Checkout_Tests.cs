using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckoutKata.Tests
{
    public class Checkout_Tests
    {
        private IEnumerable<Product> _products;

        public Checkout_Tests()
        {
            _products = new[]
            {
                new Product() { SKU = 'A', UnitPrice = 10 },
                new Product() { SKU = 'B', UnitPrice = 15 }
            };
        }

        [Fact]
        public void Checkout_AddingBasket_PopulatesBasketAsExpected()
        {
            //Arrange
            var checkout = new Checkout(_products);

            //Act
            checkout.Add("A");

            //Assert
            var numberOfItemsInBasket = checkout.Basket.Count();
            var itemInBasket = checkout.Basket.First();

            Assert.Equal(1, numberOfItemsInBasket);
            Assert.Equal('A', itemInBasket.SKU);
        }

        [Theory]
        [InlineData("A", 1, 10)]
        [InlineData("AA", 2, 20)]
        [InlineData("AAA", 3, 30)]
        [InlineData("B", 1, 15)]
        [InlineData("BB", 2, 30)]
        public void Checkout_AddingMultipleItemsToBasket_PopulatesBasketAsExpected(string basket, int expectedItems, decimal expectedValue)
        {
            //Arrange
            var checkout = new Checkout(_products);

            //Act
            checkout.Add(basket);

            //Assert
            var numberOfItemsInBasket = checkout.Basket.Count();
            var valueOfBasket = checkout.Basket.Sum(x => x.UnitPrice);

            Assert.Equal(expectedItems, numberOfItemsInBasket);
            Assert.Equal(expectedValue, valueOfBasket);
        }

        [Fact]
        public void Checkout_AddingUnknownItem_ThrowsException()
        {
            //Arrange
            var checkout = new Checkout(_products);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => checkout.Add("X"));
        }

        [Fact]
        public void Checkout_AddingValidAndUnknownItem_ThrowsException()
        {
            //Arrange
            var checkout = new Checkout(_products);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => checkout.Add("AAX"));
        }


    }
}
