using ErgastApi.Client.Attributes;
using ErgastApi.Responses.RaceInfo;

namespace ErgastApi.Requests.Standard
{
    public class RaceListRequest : StandardRequest<RaceListResponse>
    {
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        [UrlTerminator, UrlSegment("races")]
        protected object Races { get; }
    }
}