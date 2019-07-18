using System;
using ErgastApi.Exceptions;
using ErgastApi.Requests;
using FluentAssertions;
using Xunit;

namespace ErgastApi.Tests.Requests.Standard
{
    public class SeasonListRequestTests
    {
        private const string ExpectedMessageFormat = nameof(SeasonListRequest.ConstructorStanding) + " and " +
                                                     nameof(SeasonListRequest.DriverStanding) + " *";

        [Theory]
        [AutoMockedData(nameof(SeasonListRequest.CircuitId))]
        [AutoMockedData(nameof(SeasonListRequest.FinishingPosition))]
        [AutoMockedData(nameof(SeasonListRequest.FinishingStatus))]
        [AutoMockedData(nameof(SeasonListRequest.FastestLapRank))]
        [AutoMockedData(nameof(SeasonListRequest.StartingPosition))]
        public void Verify_DriverStanding_NotNull_ShouldThrowIfNotAllowedPropertyIsSet(string propertyName)
        {
            var request = new SeasonListRequest {DriverStanding = 1};
            request.SetNonNullValue(propertyName);

            Action act = request.Verify;

            act.Should().Throw<ErgastInvalidRequestException>().WithMessage(ExpectedMessageFormat);
        }

        [Theory]
        [AutoMockedData(nameof(SeasonListRequest.CircuitId))]
        [AutoMockedData(nameof(SeasonListRequest.FinishingPosition))]
        [AutoMockedData(nameof(SeasonListRequest.FinishingStatus))]
        [AutoMockedData(nameof(SeasonListRequest.FastestLapRank))]
        [AutoMockedData(nameof(SeasonListRequest.StartingPosition))]
        public void Verify_ConstructorStanding_NotNull_ShouldThrowIfNotAllowedPropertyIsSet(string propertyName)
        {
            var request = new SeasonListRequest {ConstructorStanding = 1};
            request.SetNonNullValue(propertyName);

            Action act = request.Verify;

            act.Should().Throw<ErgastInvalidRequestException>().WithMessage(ExpectedMessageFormat);
        }

        [Theory]
        [AutoMockedData(nameof(SeasonListRequest.CircuitId))]
        [AutoMockedData(nameof(SeasonListRequest.FinishingPosition))]
        [AutoMockedData(nameof(SeasonListRequest.FinishingStatus))]
        [AutoMockedData(nameof(SeasonListRequest.FastestLapRank))]
        [AutoMockedData(nameof(SeasonListRequest.StartingPosition))]
        public void Verify_ConstructorStandingAndDriverStanding_NotNull_ShouldThrowIfNotAllowedPropertyIsSet(string propertyName)
        {
            var request = new SeasonListRequest {ConstructorStanding = 1, DriverStanding = 1};
            request.SetNonNullValue(propertyName);

            Action act = request.Verify;

            act.Should().Throw<ErgastInvalidRequestException>().WithMessage(ExpectedMessageFormat);
        }

        [Theory]
        [AutoMockedData(nameof(SeasonListRequest.CircuitId))]
        [AutoMockedData(nameof(SeasonListRequest.FinishingPosition))]
        [AutoMockedData(nameof(SeasonListRequest.FinishingStatus))]
        [AutoMockedData(nameof(SeasonListRequest.FastestLapRank))]
        [AutoMockedData(nameof(SeasonListRequest.StartingPosition))]
        public void Verify_ConstructorStandingAndDriverStanding_Null_ShouldNotThrowIfNotAllowedPropertyIsSet(string propertyName)
        {
            var request = new SeasonListRequest {ConstructorStanding = null, DriverStanding = null};
            request.SetNonNullValue(propertyName);

            Action act = request.Verify;

            act.Should().NotThrow<ErgastInvalidRequestException>();
        }
    }
}
