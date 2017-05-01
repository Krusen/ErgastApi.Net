using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests.Standard
{
    public class SeasonListRequest : StandardRequest<ISeasonResponse>
    {
        public SeasonListRequest()
        {
        }

        public SeasonListRequest(ErgastRequestSettings settings) : base(settings)
        {
        }

        // Value not used
        [QueryTerminator, QueryMethod("seasons")]
        protected object Seasons { get; }
    }
}