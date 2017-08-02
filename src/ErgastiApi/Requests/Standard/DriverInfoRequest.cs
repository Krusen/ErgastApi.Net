using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    public class DriverInfoRequest : StandardRequest<DriverResponse>
    {
        [UrlTerminator]
        public override string DriverId { get; set; }
    }
}
