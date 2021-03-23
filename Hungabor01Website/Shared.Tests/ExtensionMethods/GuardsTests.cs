using Shared.ExtensionMethods;
using System;
using Xunit;

namespace Shared.Tests.ExtesnionMethods
{
    public class GuardsTests
    {
        [Fact]
        public void ThrowExceptionIfNull_ValidData_NotThrowException()
        {
            var obj = new object();
            obj.ThrowExceptionIfNull(nameof(obj));

            var emptyString = string.Empty;
            emptyString.ThrowExceptionIfNull(nameof(emptyString));
        }

        [Theory]
        [InlineData(null)]
        public void ThrowExceptionIfNull_InvalidData_ThrowArgumentNullException(object obj)
        {
            var e = Assert.Throws<ArgumentNullException>(() => obj.ThrowExceptionIfNull(nameof(obj)));
            Assert.Equal($"Value cannot be null. (Parameter '{nameof(obj)}')", e.Message);
        }

        [Theory]
        [InlineData("some string")]
        [InlineData("  a   ")]
        public void ThrowExceptionIfNullOrWhiteSpace_ValidData_NotThrowException(string str)
        {
            str.ThrowExceptionIfNullOrWhiteSpace(nameof(str));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        public void ThrowExceptionIfNullOrWhiteSpace_InvalidData_ThrowArgumentException(string str)
        {
            var e = Assert.Throws<ArgumentException>(() => str.ThrowExceptionIfNullOrWhiteSpace(nameof(str)));
            Assert.Equal(nameof(str), e.Message);
        }

        [Fact]
        public void ThrowExceptionIfNullOrWhiteSpace_StringEmptyData_ThrowArgumentException()
        {
            var str = string.Empty;
            var e = Assert.Throws<ArgumentException>(() => str.ThrowExceptionIfNullOrWhiteSpace(nameof(str)));
            Assert.Equal(nameof(str), e.Message);
        }
    }
}
