using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    public class RaceListRequest : StandardRequest<RaceListResponse>
    {
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        [UrlTerminator, UrlSegment("races")]
        protected object Races { get; }
    }
}