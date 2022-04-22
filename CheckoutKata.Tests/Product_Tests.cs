using System;
using Xunit;

namespace CheckoutKata.Tests
{
    public class Product_Tests
    {
        [Fact]
        public void Product_UnitPrice_ReturnsAsExpected()
        {
            //Arrange
            var product = new Product();
            var unitPrice = new Random().Next();

            //Act
            product.UnitPrice = unitPrice;

            //Assert
            Assert.Equal(unitPrice, product.UnitPrice);
        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        [InlineData('D')]
        public void Product_SKU_ReturnsAsExpected(char test)
        {
            //Arrange
            var product = new Product();

            //Act
            product.SKU = test;

            //Assert
            Assert.Equal(test, product.SKU);
        }

    }
}
