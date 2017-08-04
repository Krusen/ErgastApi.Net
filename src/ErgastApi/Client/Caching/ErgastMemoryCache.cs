using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErgastApi.Extensions;
using ErgastApi.Responses;

namespace ErgastApi.Client.Caching
{
    public class ErgastMemoryCache : IErgastCache
    {
        private static readonly TimeSpan CleanupInterval = TimeSpan.FromSeconds(60);

        private static readonly TimeSpan DefaultCacheEntryLifetime = TimeSpan.FromHours(1);

        protected CleanupWorker Cleaner { get; set; }

        protected ConcurrentDictionary<string, CacheEntry<ErgastResponse>> Cache { get; } = new ConcurrentDictionary<string, CacheEntry<ErgastResponse>>();

        // TODO: Doc - does not affect already cached items
        public TimeSpan CacheEntryLifetime { get; set; }

        public ErgastMemoryCache()
            : this(DefaultCacheEntryLifetime)
        {
        }

        public ErgastMemoryCache(TimeSpan cacheEntryLifetime)
        {
            CacheEntryLifetime = cacheEntryLifetime;
            Cleaner = new CleanupWorker(Cache, CleanupInterval);
        }

        public void AddOrReplace(string url, ErgastResponse response)
        {
            var expiration = DateTimeOffset.UtcNow + CacheEntryLifetime;

            var entry = new CacheEntry<ErgastResponse>
            {
                Item = response,
                Expiration = expiration
            };

            Cache[url] = entry;
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            Cleaner.Dispose();
        }

        public class CleanupWorker : IDisposable
        {
            private ConcurrentDictionary<string, CacheEntry<ErgastResponse>> Collection { get; }

            private TimeSpan Interval { get; }

            private CancellationTokenSource CancellationTokenSource { get; set; }

            public Task CleanupTask { get; private set; }

            public CleanupWorker(ConcurrentDictionary<string, CacheEntry<ErgastResponse>> collection, TimeSpan interval)
            {
                Collection = collection;
                Interval = interval;

                Start();
            }

            public void Start()
            {
                CancellationTokenSource = new CancellationTokenSource();
                var token = CancellationTokenSource.Token;
                CleanupTask = RunTask(token);
            }

            private Task RunTask(CancellationToken cancellationToken)
            {
                return Task.Run(async () =>
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        await Task.Delay(Interval, cancellationToken).ConfigureAwait(false);

                        var now = DateTimeOffset.UtcNow;
                        var expiredEntries = Collection.Where(x => x.Value.Expiration < now);

                        foreach (var entry in expiredEntries)
                        {
                            Collection.TryRemove(entry.Key, out _);
                        }
                    }
                }, cancellationToken);
            }

            public void Stop()
            {
                CancellationTokenSource?.Cancel();
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposing) return;

                CancellationTokenSource?.Cancel();
                CancellationTokenSource?.Dispose();

                CleanupTask?.WaitSafely();
            }
        }
    }
}