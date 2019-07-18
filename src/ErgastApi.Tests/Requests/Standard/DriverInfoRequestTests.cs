using System;
using ErgastApi.Exceptions;
using ErgastApi.Requests;
using FluentAssertions;
using Xunit;

namespace ErgastApi.Tests.Requests.Standard
{
    public class DriverInfoRequestTests
    {
        [Theory]
        [AutoMockedData(nameof(DriverInfoRequest.CircuitId))]
        [AutoMockedData(nameof(DriverInfoRequest.FinishingPosition))]
        [AutoMockedData(nameof(DriverInfoRequest.FinishingStatus))]
        [AutoMockedData(nameof(DriverInfoRequest.FastestLapRank))]
        [AutoMockedData(nameof(SeasonListRequest.StartingPosition))]
        public void Verify_DriverStanding_Null_ShouldNotThrowIfNotAllowedPropertyIsSet(string propertyName)
        {
            var request = new DriverInfoRequest { DriverStanding = null };
            request.SetNonNullValue(propertyName);

            Action act = request.Verify;

            act.Should().NotThrow<ErgastInvalidRequestException>();
        }

        [Theory]
        [AutoMockedData(nameof(DriverInfoRequest.CircuitId))]
        [AutoMockedData(nameof(DriverInfoRequest.FinishingPosition))]
        [AutoMockedData(nameof(DriverInfoRequest.FinishingStatus))]
        [AutoMockedData(nameof(DriverInfoRequest.FastestLapRank))]
        [AutoMockedData(nameof(SeasonListRequest.StartingPosition))]
        public void Verify_DriverStanding_NotNull_ShouldThrowIfNotAllowedPropertyIsSet(string propertyName)
        {
            var request = new DriverInfoRequest { DriverStanding = 1 };
            request.SetNonNullValue(propertyName);

            Action act = request.Verify;

            act.Should().Throw<ErgastInvalidRequestException>().WithMessage($"{nameof(DriverInfoRequest.DriverStanding)} *");
        }
    }
}
