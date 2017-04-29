using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Filters
{
    public interface IQualifyingFilter
    {
        // TODO: Docu: only supported from 2003+
        IPageableQuery Qualifying();
    }
}