using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp() { _stack = new Stack<string>(); }

        [Test]
        public void Push_WhenArgIsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void Push_WhenArgHasValue_AddsObjToTheStackAndIncrementsCountBy1()
        {
            _stack.Push("a");

            Assert.That(_stack.Count, Is.EqualTo(1));
        }
        [Test]
        public void Pop_WhenStackIsEmpty_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InstanceOf<InvalidOperationException>());
        }
        [Test]
        public void Pop_WhenStackHasElements_PopsTheTopElement()
        {
            _stack.Push("a");
            _stack.Push("b");
            var result = _stack.Pop();

            Assert.That(result, Is.EqualTo("b"));
        }
        [Test]
        public void Pop_WhenStackHasElements_DecreasesCountOfStackByOne()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(1));
        }
        [Test]
        public void Peek_WhenStackIsEmpty_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InstanceOf<InvalidOperationException>());
        }
        [Test]
        public void Peek_WhenStackHasItems_ReturnsTheTopStackElement()
        {
            _stack.Push("a");

            Assert.That(_stack.Peek(), Is.EqualTo("a"));
        }
        [Test]
        public void Peek_WhenStackHasItems_DoesNotRemoveTheElementsFromTheStack()
        {
            _stack.Push("a");

            Assert.That(_stack.Count, Is.EqualTo(1));
        }
        [Test]
        public void Count_WhenStackIsEmpty_ReturnsZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }
    }
}
