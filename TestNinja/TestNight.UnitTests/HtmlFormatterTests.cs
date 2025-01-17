using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        //this is a test case for a testing a string output type
        [Test]
        [TestCase("a","<strong>a</strong>")]
        public void FormatAsBold_WhenCalled_ReturnsStringWrappedWithStrongElement(string input, string expectedResult)
        {
            var htmlFormatter = new HtmlFormatter();

            var result = htmlFormatter.FormatAsBold(input);

            //specific
            Assert.That(result, Is.EqualTo(expectedResult).IgnoreCase);

            //General case
            /*Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            Assert.That(result, Does.Contain(input).IgnoreCase);*/
        }
    }
}
