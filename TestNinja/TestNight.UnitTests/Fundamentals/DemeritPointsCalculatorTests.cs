using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _pointsCalculator;
        [SetUp]
        public void SetUp()
        { 
            _pointsCalculator = new DemeritPointsCalculator();
        }
        [Test]
        [TestCase(301)]
        [TestCase(-1)]
        public void CalculateDemeritPoints_WhenSpeedIsLessThanZeroOrOverMaxSpeed_ThrowsArgumentOutOfRangeException(int speed)
        {
            Assert.That(() => _pointsCalculator.CalculateDemeritPoints(speed), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        [TestCase(64)]
        [TestCase(0)]
        [TestCase(65)]
        public void CalculateDemeritPoints_WhenSpeedIsLessThanOrEqualToSpeedLimit_ReturnsZero(int speed)
        {
            var points = _pointsCalculator.CalculateDemeritPoints(speed);

            Assert.That(points, Is.EqualTo(0));
        }
        [Test]
        [TestCase(80, 3)]
        [TestCase(70, 1)]
        public void CalculateDemeritPoints_WhenSpeedIsOverTheSpeedLimit_ReturnsDemeritPoints(int speed, int expectedOutput)
        {
            var points = _pointsCalculator.CalculateDemeritPoints(speed);

            Assert.That(points, Is.EqualTo(expectedOutput));
        }
    }
}
