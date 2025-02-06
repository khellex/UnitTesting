using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_ShouldStoreTheOrder()
        {
            var storageMock = new Mock<IStorage>();
            var orderService = new OrderService(storageMock.Object);

            var order = new Order();
            var result = orderService.PlaceOrder(order);

            storageMock.Verify(s => s.Store(order));
        }
    }
}
