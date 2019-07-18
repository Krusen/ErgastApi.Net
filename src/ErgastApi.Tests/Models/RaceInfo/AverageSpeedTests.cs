using ErgastApi.Responses.Models;
using ErgastApi.Responses.Models.RaceInfo;
using FluentAssertions;
using Xunit;

namespace ErgastApi.Tests.Models.RaceInfo
{
    public class AverageSpeedTests
    {
        [Fact]
        public void SpeedInKph_UnitKph_ReturnsSameAsSpeed()
        {
            var avg = new MockAverageSpeed(123, SpeedUnit.Kph);

            avg.SpeedInKph.Should().Be(123);
        }

        [Fact]
        public void SpeedInKph_UnitMiles_ReturnsConvertedSpeed()
        {
            var avg = new MockAverageSpeed(100, SpeedUnit.Mph);

            avg.SpeedInKph.Should().Be(160.93);
        }

        [Fact]
        public void SpeedInKph_UnitUnknown_ReturnsNull()
        {
            var avg = new MockAverageSpeed(100, SpeedUnit.Unknown);

            avg.SpeedInKph.Should().BeNull();
        }

        [Fact]
        public void SpeedInMph_UnitMiles_ReturnsSameAsSpeed()
        {
            var avg = new MockAverageSpeed(123, SpeedUnit.Mph);

            avg.SpeedInMph.Should().Be(123);
        }

        [Fact]
        public void SpeedInMph_UnitKilometers_ReturnsConvertedSpeed()
        {
            var avg = new MockAverageSpeed(100, SpeedUnit.Kph);

            avg.SpeedInMph.Should().Be(62.14);
        }

        [Fact]
        public void SpeedInMph_UnitUnknown_ReturnsNull()
        {
            var avg = new MockAverageSpeed(100, SpeedUnit.Unknown);

            avg.SpeedInMph.Should().BeNull();
        }

        private class MockAverageSpeed : AverageSpeed
        {
            public MockAverageSpeed(double speed, SpeedUnit unit)
            {
                Speed = speed;
                Unit = unit;
            }
        }
    }
}
