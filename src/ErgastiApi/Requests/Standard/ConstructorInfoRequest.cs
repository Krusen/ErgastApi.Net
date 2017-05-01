using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests.Standard
{
    public class ConstructorInfoRequest : StandardRequest<IConstructorResponse>
    {
        public ConstructorInfoRequest()
        {
        }

        public ConstructorInfoRequest(ErgastRequestSettings settings) : base(settings)
        {
        }

        [QueryTerminator]
        public override string ConstructorId { get; set; }
    }
}