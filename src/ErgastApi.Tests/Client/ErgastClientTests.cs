using System;
using System.Threading.Tasks;
using ErgastApi.Abstractions;
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

        private IHttpClient HttpClient { get; set; }

        private IUrlBuilder UrlBuilder { get; }

        public ErgastClientTests()
        {
            Cache = Substitute.For<IErgastCache>();
            UrlBuilder = Substitute.For<IUrlBuilder>();
            HttpClient = Substitute.For<IHttpClient>();

            Client = new ErgastClient
            {
                Cache = Cache,
                HttpClient = HttpClient,
                UrlBuilder = UrlBuilder
            };
        }

        [Fact]
        public void Constructor_WithApiBase_SetsApiBase()
        {
            var apiRoot = "http://example.com";
            var client = new ErgastClient(apiRoot);
            client.ApiBase.Should().Be(apiRoot);
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
        public void ApiBase_Set_NonUrlShouldThrowArgumentException(string url)
        {
            Action act = () => Client.ApiBase = url;
            act.ShouldThrow<ArgumentException>();
        }

        [Theory]
        [AutoMockedData("http://example.com")]
        [AutoMockedData("https://example.com")]
        public void ApiBase_Set_ShouldAcceptHttpAndHttpsUrls(string url)
        {
            Client.ApiBase = url;
            Client.ApiBase.Should().Be(url);
        }

        [Theory]
        [AutoMockedData("http://example.com/api/")]
        [AutoMockedData("https://example.com/")]
        public void ApiBase_Set_ShouldRemoveTrailingSlash(string url)
        {
            Client.ApiBase = url;
            Client.ApiBase.Should().Be(url.TrimEnd('/'));
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
