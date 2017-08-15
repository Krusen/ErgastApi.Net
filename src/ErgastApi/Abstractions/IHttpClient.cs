using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ErgastApi.Abstractions
{
    public interface IHttpClient : IDisposable
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}