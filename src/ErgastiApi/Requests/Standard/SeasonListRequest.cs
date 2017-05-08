using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests.Standard
{
    public class SeasonListRequest : StandardRequest<SeasonResponse>
    {
        // Value not used
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        [UrlTerminator, UrlSegment("seasons")]
        protected object Seasons { get; }
    }
}