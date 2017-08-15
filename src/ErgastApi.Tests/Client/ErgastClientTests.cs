using System;
using System.Threading.Tasks;
using ErgastApi.Client;
using ErgastApi.Client.Caching;
using ErgastApi.Requests;
using ErgastApi.Responses;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ErgastApi.Tests.Client
{
    public class ErgastClientTests
    {
        private ErgastClient Client { get; }

        private IErgastCache Cache { get; }

        private IUrlBuilder UrlBuilder { get; }

        public ErgastClientTests()
        {
            Cache = Substitute.For<IErgastCache>();
            UrlBuilder = Substitute.For<IUrlBuilder>();

            Client = new ErgastClient
            {
                Cache = Cache,
                UrlBuilder = UrlBuilder
            };
        }

        [Theory]
        [AutoMockedData("invalid string")]
        [AutoMockedData("C:\\")]
        [AutoMockedData("C:")]
        [AutoMockedData("ftp://example.com")]
        [AutoMockedData("ftp://example.com/")]
        [AutoMockedData("C:\\example.txt")]
        [AutoMockedData("/example/api")]
        [AutoMockedData("example/api")]
        public void ApiRoot_Set_NonUrlShouldThrowArgumentException(string url)
        {
            Action act = () => Client.ApiRoot = url;
            act.ShouldThrow<ArgumentException>();
        }

        [Theory]
        [AutoMockedData("http://example.com")]
        [AutoMockedData("https://example.com")]
        public void ApiRoot_Set_ShouldAcceptHttpAndHttpsUrls(string url)
        {
            Client.ApiRoot = url;
            Client.ApiRoot.Should().Be(url);
        }

        [Theory]
        [AutoMockedData("http://example.com/api/")]
        [AutoMockedData("https://example.com/")]
        public void ApiRoot_Set_ShouldRemoveTrailingSlash(string url)
        {
            Client.ApiRoot = url;
            Client.ApiRoot.Should().Be(url.TrimEnd('/'));
        }

        [Theory]
        [AutoMockedData]
        public void GetResponseAsync_RequestWithRoundWithoutSeason_ThrowsInvalidOperationException(ErgastRequest<ErgastResponse> request)
        {
            // Arrange
            request.Season = null;
            request.Round = "1";

            // Act
            Func<Task> act = async () => await Client.GetResponseAsync(request);

            // Assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Theory]
        [AutoMockedData]
        public async Task GetResponseAsync_ReturnsCachedResponse(ErgastResponse expectedResponse)
        {
            Cache.Get<ErgastResponse>(null).ReturnsForAnyArgs(expectedResponse);

            var response = await Client.GetResponseAsync<ErgastResponse>(null);

            response.Should().Be(expectedResponse);
        }
    }
}
