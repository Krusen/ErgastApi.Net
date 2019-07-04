using System;
using ErgastApi.Responses;
using Microsoft.Extensions.Caching.Memory;

namespace ErgastApi.Client.Caching
{
    public class ErgastMemoryCache : IErgastCache
    {
        private static readonly TimeSpan DefaultCacheEntryLifetime = TimeSpan.FromHours(1);

        private MemoryCache Cache { get; set; } = new MemoryCache(new MemoryCacheOptions());

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
            Cache = new MemoryCache(new MemoryCacheOptions());
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