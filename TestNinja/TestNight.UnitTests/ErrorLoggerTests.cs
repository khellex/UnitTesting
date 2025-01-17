using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_LogsTheLastError()
        {
            var errorLogger = new ErrorLogger();

            errorLogger.Log("abc");

            Assert.That(errorLogger.LastError, Is.EqualTo("abc"));
        }
    }
}
