using CheckoutKata.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckoutKata.Tests
{
    public class Discount_Tests
    {
        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        [InlineData('D')]
        public void Discount_SKU_ReturnsAsExpected(char test)
        {
            //Arrange
            var discount = new Discount();

            //Act
            discount.SKU = test;

            //Assert
            Assert.Equal(test, discount.SKU);
        }

        [Theory]
        [InlineData(DiscountType.MultibuyPrice)]
        [InlineData(DiscountType.MultibuyPercentage)]
        public void Discount_DiscountType_ReturnsAsExpected(DiscountType discountType)
        {
            //Arrange
            var discount = new Discount();

            //Act
            discount.DiscountType = discountType;

            //Assert
            Assert.Equal(discountType, discount.DiscountType);
        }

        [Fact]
        public void Discount_DiscountPriceForGroup_ReturnsAsExpected()
        {
            //Arrange
            var discount = new Discount();
            var discountPriceForGroup = new Random().Next();

            //Act
            discount.DiscountPriceForGroup = discountPriceForGroup;

            //Assert
            Assert.Equal(discountPriceForGroup, discount.DiscountPriceForGroup);
        }

        [Fact]
        public void Discount_DiscountPercentagePerItem_ReturnsAsExpected()
        {
            //Arrange
            var discount = new Discount();
            var discountPercentagePerItem = new Random().Next();

            //Act
            discount.DiscountPercentagePerItem = discountPercentagePerItem;

            //Assert
            Assert.Equal(discountPercentagePerItem, discount.DiscountPercentagePerItem);
        }


    }
}
