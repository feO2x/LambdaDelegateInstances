using System;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public sealed class LambdaDelegateInstancesTests
    {
        [Fact]
        public void LambdasCreatingObject()
        {
            var delegate1 = SimpleException();
            var delegate2 = SimpleException();

            delegate1.Should().BeSameAs(delegate2);
        }

        private static Func<Exception> SimpleException()
        {
            return () => new Exception();
        }

        [Fact]
        public void LambdasWithConstantString()
        {
            var delegate1 = ExceptionWithStaticText();
            var delegate2 = ExceptionWithStaticText();

            delegate1.Should().BeSameAs(delegate2);
        }

        private static Func<Exception> ExceptionWithStaticText()
        {
            return () => new Exception("This exception is provided with a constant string");
        }

        [Fact]
        public void LambdasWithNameof()
        {
            var delegate1 = ExceptionWithNameofInMessage("someText");
            var delegate2 = ExceptionWithNameofInMessage("someText");

            delegate1.Should().BeSameAs(delegate2);
        }

        private static Func<Exception> ExceptionWithNameofInMessage(string content)
        {
            return () => new Exception($"This message contains a parameter name: {nameof(content)}");
        }

        [Fact]
        public void LambasWithComputedString()
        {
            var delegate1 = ExceptionWithContentCaptured("someText");
            var delegate2 = ExceptionWithContentCaptured("someText");

            delegate1.Should().NotBeSameAs(delegate2);
        }

        private static Func<Exception> ExceptionWithContentCaptured(string content)
        {
            return () => new Exception($"This message contains the content of a parameter: {content}");
        }
    }
}