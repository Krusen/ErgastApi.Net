using ErgastApi.Requests;

namespace ErgastApi.Client
{
    public interface IUrlBuilder
    {
        string Build(IErgastRequest request);
    }
}