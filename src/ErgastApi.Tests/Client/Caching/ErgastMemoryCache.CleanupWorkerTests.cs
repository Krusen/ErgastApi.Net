using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using ErgastApi.Client.Caching;
using ErgastApi.Responses;
using FluentAssertions;
using Xunit;

namespace ErgastApi.Tests.Client.Caching
{
    public class ErgastMemoryCacheCleanupWorkerTests
    {
        private IDictionary<string, CacheEntry<ErgastResponse>> Cache { get; }

        public ErgastMemoryCacheCleanupWorkerTests()
        {
            Cache = new ConcurrentDictionary<string, CacheEntry<ErgastResponse>>();
        }

        [Theory]
        [AutoMockedData]
        public async Task RemovesExpiredItemsContinously(string key1, CacheEntry<ErgastResponse> entry1, string key2, CacheEntry<ErgastResponse> entry2)
        {
            // Arrange
            entry1.Expiration = DateTime.Now.AddDays(-1);
            entry2.Expiration = DateTime.Now.AddDays(1);
            Cache.Add(key1, entry1);
            Cache.Add(key2, entry2);

            // Act
            var worker = CreateCleanupWorker(TimeSpan.FromMilliseconds(10));
            await Task.Delay(100);

            // Assert
            Cache.Should().HaveCount(1);

            entry2.Expiration = DateTime.Now.AddDays(-1);
            await Task.Delay(100);

            Cache.Should().BeEmpty();
            worker.CleanupTask.IsCompleted.Should().BeFalse();
        }

        [Fact]
        public void Dispose_StopsCleanupTask()
        {
            // Arrange
            var worker = CreateCleanupWorker(TimeSpan.FromDays(1));

            // Act
            worker.Dispose();

            // Assert
            worker.CleanupTask.IsCompleted.Should().BeTrue();
        }

        [Fact]
        public async Task Stop_StopsCleanupTask()
        {
            // Arrange
            var worker = CreateCleanupWorker(TimeSpan.FromDays(1));

            // Act
            worker.Stop();
            await Task.WhenAny(worker.CleanupTask, Task.Delay(100));

            // Assert
            worker.CleanupTask.IsCompleted.Should().BeTrue();
        }

        [Fact]
        public void Stop_CanBeCalledMultipleTimesWithoutThrowingException()
        {
            // Arrange
            var worker = CreateCleanupWorker(TimeSpan.FromDays(1));

            // Act
            Action act = () =>
            {
                worker.Stop();
                worker.Stop();
                worker.Stop();
            };

            // Assert
            act.ShouldNotThrow();
        }

        [Fact]
        public void CanBeStartedAndStoppedMultipleTimes()
        {
            // Arrange
            var worker = CreateCleanupWorker(TimeSpan.FromDays(1));

            // Act
            worker.Start();
            worker.Stop();
            worker.Start();
            worker.Stop();
            worker.Start();

            // Assert
            worker.CleanupTask.IsCompleted.Should().BeFalse();
        }

        private ErgastMemoryCache.CleanupWorker CreateCleanupWorker(TimeSpan interval)
        {
            var cache = Cache as ConcurrentDictionary<string, CacheEntry<ErgastResponse>>;
            return new ErgastMemoryCache.CleanupWorker(cache, interval);
        }
    }
}
