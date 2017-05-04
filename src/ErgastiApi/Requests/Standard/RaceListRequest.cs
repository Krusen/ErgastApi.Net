using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests.Standard
{
    public class RaceListRequest : StandardRequest<RaceResponse<Race>>
    {
        public RaceListRequest()
        {
        }

        public RaceListRequest(ErgastRequestSettings settings) : base(settings)
        {
        }

        // Value not used
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        [QueryTerminator, QueryMethod("races")]
        protected object Races { get; }
    }
}