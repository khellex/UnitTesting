using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger _logger;
        [SetUp]
        public void SetUp() { _logger = new ErrorLogger(); }
        [Test]
        public void Log_WhenCalled_LogsTheLastError()
        {
            var errorLogger = _logger;

            errorLogger.Log("abc");

            Assert.That(errorLogger.LastError, Is.EqualTo("abc"));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")] //empty string
        [TestCase(" ")] //white space
        public void Log_InputNullOrEmptyOrWhiteSpace_ThrowsArgumentNullException(string errorInput)
        {
            var errorLogger = _logger;

            Assert.That(() => errorLogger.Log(errorInput), Throws.InstanceOf<ArgumentNullException>());
        }
        [Test]
        public void Log_EventHandlerIsEmpty_RaiseErrorLoggedEvent()
        {
            //in this test case, the event handler will always hit the invoke
            //function, but if due to some error it does not hit, then we have
            //written the test case to validate that scenario  
            var errorLogger = _logger;

            //the guid will always have a value as long as the event handler is 
            //hit, when the event handler fails, the guid will no longer have
            //the value and the unit test will fail

            var logEventId = Guid.Empty;
            //first you need to subscribe to that event
            errorLogger.ErrorLogged += (sender, args) => { logEventId = args; };

            errorLogger.Log("a");

            Assert.That(logEventId, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
