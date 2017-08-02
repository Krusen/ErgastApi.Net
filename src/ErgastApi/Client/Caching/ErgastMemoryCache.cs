using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErgastApi.Responses;

namespace ErgastApi.Client.Caching
{
    public class ErgastMemoryCache : IErgastCache
    {
        private static readonly TimeSpan CleanupTaskInterval = TimeSpan.FromSeconds(60);

        private Task CleanupTask { get; }

        private CancellationTokenSource CleanupTaskCancellationTokenSource { get; } = new CancellationTokenSource();

        protected ConcurrentDictionary<string, CacheEntry<ErgastResponse>> Cache { get; } = new ConcurrentDictionary<string, CacheEntry<ErgastResponse>>();

        public TimeSpan CacheEntryLifetime { get; set; } = TimeSpan.FromHours(1);

        public ErgastMemoryCache()
        {
            CleanupTask = RemoveExpiredEntries(CleanupTaskCancellationTokenSource.Token);
        }

        public ErgastMemoryCache(TimeSpan cacheEntryLifetime)
            : this()
        {
            CacheEntryLifetime = cacheEntryLifetime;
        }

        public void AddOrReplace(string url, ErgastResponse response)
        {
            var expiration = DateTimeOffset.UtcNow + CacheEntryLifetime;

            var entry = new CacheEntry<ErgastResponse>
            {
                Item = response,
                Expiration = expiration
            };

            Cache.AddOrUpdate(url, key => entry, (key, value) => entry);
        }

        public T Get<T>(string url) where T : ErgastResponse
        {
            Cache.TryGetValue(url, out CacheEntry<ErgastResponse> entry);

            if (entry == null || entry.Expiration < DateTimeOffset.UtcNow)
                return null;

            return (T) entry.Item;
        }

        public bool Remove(string url)
        {
            return Cache.TryRemove(url, out _);
        }

        public void Clear()
        {
            Cache.Clear();
        }

        private async Task RemoveExpiredEntries(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var now = DateTimeOffset.UtcNow;
                var expiredEntries = Cache.Where(x => x.Value.Expiration < now);

                foreach (var entry in expiredEntries)
                {
                    Cache.TryRemove(entry.Key, out _);
                }

                try
                {
                    await Task.Delay(CleanupTaskInterval, cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            CleanupTaskCancellationTokenSource.Cancel();
            CleanupTask.Wait();
        }
    }
}