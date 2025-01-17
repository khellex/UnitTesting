using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    /// <summary>
    /// This is a unit test class, which will use the MSTest, unit testing framework
    /// The naming convention of a unit test method is : name of the method_scenario that you want to test for_the expected outcome of the test
    /// </summary>
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange (here you will do the object initializations)
            var reservation = new Reservation();

            //Act (here you will call the method that you want to implement this unit test on)
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert (here you will make sure that the expected outcome of the method and the unit test is correct)
            Assert.That(result, Is.True);
        }
        [Test]
        public void CanBeCancelledBy_UserWhoMadeTheirReservation_ReturnsTrue()
        {
            //Arrange
            User user = new User();
            var reservation = new Reservation() { MadeBy=user };

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void CanBeCancelledBy_UserIsNotAdminOrMadeTheirReservation_ReturnsFalse()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { });

            //Assert
            Assert.IsFalse(result);
        }
    }
}
