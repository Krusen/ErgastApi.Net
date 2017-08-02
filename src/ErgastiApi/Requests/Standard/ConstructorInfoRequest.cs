using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    public class ConstructorInfoRequest : StandardRequest<ConstructorResponse>
    {
        [UrlTerminator]
        public override string ConstructorId { get; set; }
    }
}