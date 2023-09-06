using System;
using ErgastApi.Requests;
using ErgastApi.Responses;
using FluentAssertions;
using Xunit;

namespace ErgastApi.Tests.Requests
{
    public class ErgastRequestTests
    {
        private ErgastRequest<ErgastResponse> Request { get; }
        public ErgastRequestTests()
        {
            Request = new MockErgastRequest();
        }

        [Theory]
        [AutoMockedData(-1)]
        [AutoMockedData(-20)]
        [AutoMockedData(int.MinValue)]
        public void Limit_BelowZero_ThrowsArgumentOutOfRangeException(int limit)
        {
            Action act = () => Request.Limit = limit;
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [AutoMockedData(1001)]
        [AutoMockedData(50000)]
        [AutoMockedData(int.MaxValue)]
        public void Limit_AboveOneThousand_ThrowsArgumentOutOfRangeException(int limit)
        {
            Action act = () => Request.Limit = limit;
            act.Should().Throw<ArgumentOutOfRangeException>();
        }


        [Theory]
        [AutoMockedData(-1)]
        [AutoMockedData(-20)]
        [AutoMockedData(int.MinValue)]
        public void Offset_BelowZero_ThrowsArgumentOutOfRangeException(int offset)
        {
            Action act = () => Request.Offset = offset;
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [AutoMockedData(0)]
        [AutoMockedData(-1)]
        [AutoMockedData(int.MinValue)]
        public void Page_PageBelowOne_ThrowsArgumentOutOfRangeException(int page)
        {
            Action act = () => Request.Page(page, 10);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [AutoMockedData(-1)]
        [AutoMockedData(-200)]
        [AutoMockedData(int.MinValue)]
        public void Page_PageSizeBelowZero_ThrowsArgumentOutOfRangeException(int pageSize)
        {
            Action act = () => Request.Page(1, pageSize);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [AutoMockedData(1001)]
        [AutoMockedData(5000)]
        [AutoMockedData(int.MaxValue)]
        public void Page_PageSizeAboveOneThousand_ThrowsArgumentOutOfRangeException(int pageSize)
        {
            Action act = () => Request.Page(1, pageSize);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [AutoMockedData(1, 10)]
        [AutoMockedData(2, 25)]
        public void Page_SetsLimitAndOffset(int page, int pageSize)
        {
            // Arrange
            var expectedOffset = (page - 1) * pageSize;

            // Act
            Request.Page(page, pageSize);

            // Assert
            Request.Limit.Should().Be(pageSize);
            Request.Offset.Should().Be(expectedOffset);
        }

        private class MockErgastRequest : ErgastRequest<ErgastResponse>
        {

        }
    }
}
