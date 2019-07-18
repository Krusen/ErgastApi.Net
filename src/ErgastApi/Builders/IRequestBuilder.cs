using ErgastApi.Requests;

namespace ErgastApi.Builders
{
    public interface IRequestBuilder<T> where T : class, IErgastRequest
    {
        T Request { get; }
    }
}