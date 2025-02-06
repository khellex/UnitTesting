using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeRepository> _employeeRepository;
        private EmployeeController _employeeController;

        [SetUp]
        public void SetUp()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();

            _employeeController = new EmployeeController(_employeeRepository.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_RemovesTheWholeEmployeeEntryBasedOnId()
        {
            _employeeRepository.Setup(e => e.RemoveEmployee(It.IsAny<int>()));

            _employeeController.DeleteEmployee(1);

            _employeeRepository.Verify(e=>e.RemoveEmployee(It.IsAny<int>()));
        }
        [Test]
        public void DeleteEmployee_WhenCalled_RedirectsToTheEmployeesAction()
        {
            var result = _employeeController.DeleteEmployee(1);

            Assert.That(result, Is.InstanceOf<RedirectResult>());
        }
    }
}
