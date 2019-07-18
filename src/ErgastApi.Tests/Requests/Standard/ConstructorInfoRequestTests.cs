using System;
using ErgastApi.Exceptions;
using ErgastApi.Requests;
using FluentAssertions;
using Xunit;

namespace ErgastApi.Tests.Requests.Standard
{
    public class ConstructorInfoRequestTests
    {
        [Theory]
        [AutoMockedData(nameof(ConstructorInfoRequest.CircuitId))]
        [AutoMockedData(nameof(ConstructorInfoRequest.FinishingPosition))]
        [AutoMockedData(nameof(ConstructorInfoRequest.FinishingStatus))]
        [AutoMockedData(nameof(ConstructorInfoRequest.FastestLapRank))]
        [AutoMockedData(nameof(SeasonListRequest.StartingPosition))]
        public void Verify_ConstructorStanding_Null_ShouldNotThrowIfNotAllowedPropertyIsSet(string propertyName)
        {
            var request = new ConstructorInfoRequest { ConstructorStanding = null };
            request.SetNonNullValue(propertyName);

            Action act = request.Verify;

            act.Should().NotThrow<ErgastInvalidRequestException>();
        }

        [Theory]
        [AutoMockedData(nameof(ConstructorInfoRequest.CircuitId))]
        [AutoMockedData(nameof(ConstructorInfoRequest.FinishingPosition))]
        [AutoMockedData(nameof(ConstructorInfoRequest.FinishingStatus))]
        [AutoMockedData(nameof(ConstructorInfoRequest.FastestLapRank))]
        [AutoMockedData(nameof(SeasonListRequest.StartingPosition))]
        public void Verify_ConstructorStanding_NotNull_ShouldThrowIfNotAllowedPropertyIsSet(string propertyName)
        {
            var request = new ConstructorInfoRequest { ConstructorStanding = 1 };
            request.SetNonNullValue(propertyName);

            Action act = request.Verify;

            act.Should().Throw<ErgastInvalidRequestException>().WithMessage($"{nameof(ConstructorInfoRequest.ConstructorStanding)} *");
        }
    }
}
