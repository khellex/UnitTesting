using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetPrice_ForGoldCustomer_ReturnsDiscountedPrice()
        {
            var product = new Product() { ListPrice = 10};

            var result = product.GetPrice(new Customer() { IsGold = true});

            Assert.That(result, Is.EqualTo(7));
        }
        [Test]
        public void GetPrice_ForNormalCustomer_ReturnsNormalPrice()
        {
            var product = new Product() { ListPrice = 10 };

            var result = product.GetPrice(new Customer());

            Assert.That(result, Is.EqualTo(10));

        }
    }
}
