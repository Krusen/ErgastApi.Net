using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests.Standard
{
    public class CircuitInfoRequest : StandardRequest<ICircuitResponse>
    {
        public CircuitInfoRequest()
        {
        }

        public CircuitInfoRequest(ErgastRequestSettings settings) : base(settings)
        {
        }

        [QueryTerminator]
        public override string CircuitId { get; set; }
    }
}