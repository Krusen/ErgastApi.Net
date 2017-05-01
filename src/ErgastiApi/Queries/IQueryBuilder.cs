using ErgastApi.Requests;

namespace ErgastApi.Queries
{
    public interface IQueryBuilder
    {
        string BuildUrl(IErgastRequest request);
    }
}