using System;
using ErgastApi.Responses;

#if NETSTANDARD
using Microsoft.Extensions.Caching.Memory;
#else
using System.Runtime.Caching;
#endif

namespace ErgastApi.Client.Caching
{
    public class ErgastMemoryCache : IErgastCache
    {
        private static readonly TimeSpan DefaultCacheEntryLifetime = TimeSpan.FromHours(1);

#if NETSTANDARD
        private MemoryCache Cache { get; set; } = new MemoryCache(new MemoryCacheOptions());
#else
        private MemoryCache Cache { get; set; } = new MemoryCache(nameof(ErgastMemoryCache));
#endif

        // TODO: Doc - does not affect already cached items
        public TimeSpan CacheEntryLifetime { get; set; }

        public ErgastMemoryCache()
            : this(DefaultCacheEntryLifetime)
        {
        }

        public ErgastMemoryCache(TimeSpan cacheEntryLifetime)
        {
            CacheEntryLifetime = cacheEntryLifetime;
        }

        public void AddOrReplace(string url, ErgastResponse response)
        {
            Cache.Set(url, response, DateTimeOffset.UtcNow + CacheEntryLifetime);
        }

        public T Get<T>(string url) where T : ErgastResponse
        {
            return Cache.Get(url) as T;
        }

        public void Remove(string url)
        {
            Cache.Remove(url);
        }

        public void Clear()
        {
            Cache.Dispose();
#if NETSTANDARD
            Cache = new MemoryCache(new MemoryCacheOptions());
#else
            Cache = new MemoryCache(nameof(ErgastMemoryCache));
#endif
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            Cache.Dispose();
        }
    }
}