using System;
using System.Net;
using System.Net.Http;
using System.Threading;
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
    public class ErgastClientTests : IDisposable
    {
        private ErgastClient Client { get; }

        private IErgastCache Cache { get; }

        private IUrlBuilder UrlBuilder { get; }

        private IHttpClient HttpClient { get; }

        private HttpResponseMessage ResponseMessage { get; }

        public ErgastClientTests()
        {
            Cache = Substitute.For<IErgastCache>();
            UrlBuilder = Substitute.For<IUrlBuilder>();
            HttpClient = Substitute.For<IHttpClient>();
            ResponseMessage = Substitute.For<HttpResponseMessage>();
            ResponseMessage.Content = new StringContent("{ Data: {} }");

            HttpClient.GetAsync(null).ReturnsForAnyArgs(x => ResponseMessage);

            Client = new ErgastClient
            {
                Cache = Cache,
                UrlBuilder = UrlBuilder,
                HttpClient = HttpClient
            };
        }

        public void Dispose()
        {
            ResponseMessage?.Dispose();
            HttpClient?.Dispose();
            Client?.Dispose();
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
            act.Should().Throw<ArgumentException>();
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
        public async Task GetResponseAsync_InvokesRequestVerifyMethod(ErgastRequest<ErgastResponse> request)
        {
            await Client.GetResponseAsync(request, CancellationToken.None);
            request.Received().Verify();
        }

        [Theory]
        [AutoMockedData]
        public async Task GetResponseAsync_ReturnsCachedResponse(ErgastResponse expectedResponse, ErgastRequest<ErgastResponse> request)
        {
            Cache.Get<ErgastResponse>(null).ReturnsForAnyArgs(expectedResponse);

            var response = await Client.GetResponseAsync(request, CancellationToken.None);

            response.Should().Be(expectedResponse);
        }

        [Theory]
        [AutoMockedData]
        public async Task GetResponseAsync_CallsTheUrlFromUrlBuilder(string url, ErgastRequest<ErgastResponse> request)
        {
            // Arrange
            var expectedUrl = Client.ApiBase + url;
            UrlBuilder.Build(request).Returns(url);

            // Act
            await Client.GetResponseAsync(request, CancellationToken.None);

            // Assert
            await HttpClient.Received().GetAsync(expectedUrl);
        }

        [Theory]
        [AutoMockedData]
        public async Task GetResponseAsync_AddsTheResponseToTheCache(ErgastRequest<ErgastResponse> request, string url)
        {
            // Arrange
            var expectedUrl = Client.ApiBase + url;
            UrlBuilder.Build(request).Returns(url);

            // Act
            await Client.GetResponseAsync(request, CancellationToken.None);

            // Assert
            Cache.Received().AddOrReplace(expectedUrl, Arg.Any<ErgastResponse>());
        }

        [Theory]
        [AutoMockedData(HttpStatusCode.BadRequest)]
        [AutoMockedData(HttpStatusCode.ServiceUnavailable)]
        [AutoMockedData(HttpStatusCode.InternalServerError)]
        [AutoMockedData(HttpStatusCode.Forbidden)]
        [AutoMockedData(HttpStatusCode.Unauthorized)]
        [AutoMockedData(HttpStatusCode.NotFound)]
        public void GetResponseAsync_ThrowsHttpRequestExceptionIfNotSuccessStatusCode(HttpStatusCode statusCode, ErgastRequest<ErgastResponse> request)
        {
            ResponseMessage.StatusCode = statusCode;

            Func<Task> act = async () => await Client.GetResponseAsync(request, CancellationToken.None);

            act.Should().Throw<HttpRequestException>();
        }

        [Theory]
        [AutoMockedData]
        public void GetResponseAsync_ThrowsExceptionIfInvalidResponse(ErgastRequest<ErgastResponse> request)
        {
            ResponseMessage.Content = new StringContent("");

            Func<Task> act = async () => await Client.GetResponseAsync(request, CancellationToken.None);

            act.Should().ThrowExactly<Exception>();
        }

        [Fact]
        public async Task GetResponseAsync_HttpResponseMessageIsDisposed()
        {
            var response = await Client.GetResponseAsync(new DriverStandingsRequest());
            ResponseMessage.Received().Dispose();
        }

        [Fact]
        public void Dispose_DisposesOfHttpClient()
        {
            Client.Dispose();
            HttpClient.Received().Dispose();
        }

        [Fact]
        public void Dispose_DisposesOfCache()
        {
            Client.Dispose();
            Cache.Received().Dispose();
        }
    }
}
