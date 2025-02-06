using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(2, "2")]
        [TestCase(16, "16")]
        [TestCase(77, "77")]
        public void GetOutput_WhenInputNumberIsNotMultipleOf3Or5_ReturnsTheInputNumber(int number, string expectedOutput)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo(expectedOutput));
        }
        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(30, "FizzBuzz")]
        [TestCase(45, "FizzBuzz")]
        public void GetOutput_WhenInputNumberIsCommonMultipleOf3And5_ReturnsFizzBuzzString(int number, string expectedOutput )
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo(expectedOutput).IgnoreCase);
        }
        [Test]
        [TestCase(3, "Fizz")]
        [TestCase(9, "Fizz")]
        [TestCase(12, "Fizz")]
        public void GetOutput_WhenInputNumberIs3OrMultipleOf3_ReturnsFizzString(int number, string expectedOutput)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo(expectedOutput).IgnoreCase);
        }
        [Test]
        [TestCase(5, "Buzz")]
        [TestCase(10, "Buzz")]
        [TestCase(20, "Buzz")]
        public void GetOutput_WhenInputNumberIs5OrMultipleOf5_ReturnsBuzzString(int number, string expectedOutput)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo(expectedOutput).IgnoreCase);
        }
    }
}
