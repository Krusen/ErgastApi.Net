using System;
using ErgastApi.Responses;

namespace ErgastApi.Client.Caching
{
    public interface IErgastCache : IDisposable
    {
        void AddOrReplace(string url, ErgastResponse response);

        void AddOrReplace(string url, ErgastResponse response, DateTimeOffset expiration);

        T Get<T>(string url) where T : ErgastResponse;

        bool Remove(string url);

        void Clear();
    }
}