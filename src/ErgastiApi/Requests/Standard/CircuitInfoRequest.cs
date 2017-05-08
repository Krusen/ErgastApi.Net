using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests.Standard
{
    public class CircuitInfoRequest : StandardRequest<CircuitResponse>
    {
        [UrlTerminator]
        public override string CircuitId { get; set; }
    }
}