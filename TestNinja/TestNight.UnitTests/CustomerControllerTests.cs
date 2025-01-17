using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_WhenIdIsZero_ReturnsNotFound()
        {
            var customer = new CustomerController();

            var result = customer.GetCustomer(0);

            //this assert can be used when the result is an instance or derivative of that class 
            //Assert.That(result, Is.InstanceOf<NotFound>());

            //this assert means the result is exactly a NotFound object
            Assert.That(result, Is.TypeOf<NotFound>());
        }
        [Test]
        public void GetCustomer_WhenIdIsOne_ReturnsOk()
        {
            var customer = new CustomerController();

            var result = customer.GetCustomer(1);

            //this assert can be used when the result is an instance or derivative of that class 
            //Assert.That(result, Is.InstanceOf<NotFound>());

            //this assert means the result is exactly a NotFound object
            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
