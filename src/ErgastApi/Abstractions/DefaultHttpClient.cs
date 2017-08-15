using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ErgastApi.Abstractions
{
    public class DefaultHttpClient : IHttpClient
    {
        private HttpClient HttpClient { get; } = new HttpClient();

        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return HttpClient.GetAsync(requestUri);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            HttpClient?.Dispose();
        }
    }
}
