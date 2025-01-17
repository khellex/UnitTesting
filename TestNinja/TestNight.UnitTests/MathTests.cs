using NUnit.Framework;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        //rather than initializing the object every time, we can decorate the property
        //with the setup attribute and it will initialize it once and we can use the
        //same instance throughout the testing 
        [SetUp]
        public void SetUp()
        {
            _math = new Math(); 
        }
        [Test]
        //[Ignore("Because I can!")] you can write ignore to, skip this particular test case when you want to focus on coding or something elsel 
        public void Add_WhenCalled_ReturnsSumOfArguments()
        {
            var result = _math.Add(1,2);

            //assert
            Assert.That(result, Is.EqualTo(3));
        }
        /// <summary>
        /// In nunit, we can create parametrized test methods, where in that way we
        /// don't need to repeat the test methods and create redundant code.
        /// </summary>
        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(2, 2, 2)]
        public void Max_WhenCalled_ReturnsTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            //assert
            Assert.That(result, Is. EqualTo(expectedResult));
        }
        [Test]
        public void GetOddNumbers_WhenCalled_ReturnsTheOddNumbersFromLimitRange()
        {
            var result = _math.GetOddNumbers(5);

            //very general approach
            //Assert.IsNotEmpty(result);

            //semi-specific
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));
            //Assert.That(result, Does.Contain(1));

            Assert.That(result, Is.EquivalentTo(new [] { 1, 3, 5 }));

            //Assert.That(result, Is.Unique); //makes sure no duplicates in the array
            //Assert.That(result, Is.Ordered); //sorts the array
        }
    }
}
