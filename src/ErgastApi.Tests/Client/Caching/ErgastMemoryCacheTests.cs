using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using ErgastApi.Client.Caching;
using ErgastApi.Responses;
using FluentAssertions;
using Xunit;

namespace ErgastApi.Tests.Client.Caching
{
    public class ErgastMemoryCacheTests
    {
        private ErgastMemoryCache Cache { get; set; }

        public ErgastMemoryCacheTests()
        {
            Cache = new ErgastMemoryCache();
        }

        [Theory]
        [AutoMockedData]
        public void ExpiredResponseIsNotReturned(string url, ErgastResponse response)
        {
            // Arrange
            Cache.CacheEntryLifetime = TimeSpan.FromMinutes(-1);
            Cache.AddOrReplace(url, response);

            // Act
            var cachedResponse = Cache.Get<ErgastResponse>(url);

            // Assert
            cachedResponse.Should().BeNull();
        }

        [Theory]
        [AutoMockedData]
        public void CachedResponseIsReturned(string url, ErgastResponse response)
        {
            // Arrange
            Cache.CacheEntryLifetime = TimeSpan.FromMinutes(1);
            Cache.AddOrReplace(url, response);

            // Act
            var cachedResponse = Cache.Get<ErgastResponse>(url);

            // Assert
            cachedResponse.Should().Be(response);
        }

        [Theory]
        [AutoMockedData]
        public async Task InternalCacheIsCleanedByTask(string url, ErgastResponse response)
        {
            // Arrange
            var cache = new MockErgastMemoryCache
            {
                CleanupInterval = TimeSpan.FromMilliseconds(10),
                CacheEntryLifetime = TimeSpan.FromMinutes(-1)
            };
            cache.AddOrReplace(url, response);

            // Pre-Assert
            cache.InternalCache.Should().HaveCount(1);

            // Act
            await Task.Delay(30);
            var cachedResponse = Cache.Get<ErgastResponse>(url);

            // Assert
            cache.InternalCache.Should().HaveCount(0);
        }


        [Theory]
        [AutoMockedData]
        public async Task InternalCacheIsNotCleanedBeforeInterval(string url, ErgastResponse response)
        {
            // Arrange
            var cache = new MockErgastMemoryCache
            {
                CleanupInterval = TimeSpan.FromMinutes(1),
                CacheEntryLifetime = TimeSpan.FromMinutes(-1)
            };
            cache.AddOrReplace(url, response);

            // Pre-Assert
            cache.InternalCache.Should().HaveCount(1);

            // Act
            await Task.Delay(100);
            var cachedResponse = Cache.Get<ErgastResponse>(url);

            // Assert
            cache.InternalCache.Should().HaveCount(1);
        }

        private class MockErgastMemoryCache : ErgastMemoryCache
        {
            public ConcurrentDictionary<string, CacheEntry<ErgastResponse>> InternalCache => Cache;
        }
    }
}
