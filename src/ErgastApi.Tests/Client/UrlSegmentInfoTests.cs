using System.Collections.Generic;
using ErgastApi.Client;
using FluentAssertions;
using Xunit;

namespace ErgastApi.Tests.Client
{
    public class UrlSegmentInfoTests
    {
        [Fact]
        public void ListSort_SortedByOrderValueWithNullLast()
        {
            // Arrange
            var order1 = new UrlSegmentInfo { Order = 1 };
            var order2 = new UrlSegmentInfo { Order = 2 };
            var orderNull = new UrlSegmentInfo { Order = null };
            var list = new List<UrlSegmentInfo> { orderNull, order1, order2 };

            // Act
            list.Sort();

            // Assert
            list.Should().ContainInOrder(order1, order2, orderNull);
        }

        [Fact]
        public void ListSort_SortedWithTerminatorLast()
        {
            // Arrange
            var order3 = new UrlSegmentInfo { Order = 3 };
            var orderNull = new UrlSegmentInfo { Order = null };
            var nameAlpha = new UrlSegmentInfo { Name = "alpha" };
            var terminator = new UrlSegmentInfo { IsTerminator = true, Order = 1, Name = "zulu"};
            var list = new List<UrlSegmentInfo> { orderNull, terminator, nameAlpha, order3 };

            // Act
            list.Sort();

            // Assert
            list.Should().EndWith(terminator);
        }

        [Fact]
        public void ListSort_WithSameOrder_SortedAlphabeticallyByNameCaseInsensitive()
        {
            // Arrange
            var nameAlpha = new UrlSegmentInfo { Order = 1, Name = "alpha" };
            var nameBeta = new UrlSegmentInfo { Order = 1, Name = "BETA" };
            var nameZulu = new UrlSegmentInfo { Order = 1, Name = "zulu" };
            var list = new List<UrlSegmentInfo> { nameZulu, nameAlpha, nameBeta };

            // Act
            list.Sort();

            // Assert
            list.Should().ContainInOrder(nameAlpha, nameBeta, nameZulu);
        }
    }
}
