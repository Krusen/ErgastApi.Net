using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    public class CircuitInfoRequest : StandardRequest<CircuitResponse>
    {
        [UrlTerminator]
        public override string CircuitId { get; set; }
    }
}