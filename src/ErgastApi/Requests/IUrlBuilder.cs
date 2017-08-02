namespace ErgastApi.Requests
{
    public interface IUrlBuilder
    {
        string Build(IErgastRequest request);
    }
}