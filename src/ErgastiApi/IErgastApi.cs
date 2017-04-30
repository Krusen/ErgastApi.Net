using ErgastApi.Interfaces.Methods;
using ErgastApi.Queries;
using ErgastApi.Queries.Default.Info;
using ErgastApi.Responses;

namespace ErgastApi
{
    public interface IErgastApi
    {
        IDriverResponse Execute(IDriverInfoQuery query);

        IConstructorResponse Execute(IConstructorInfoQuery query);

        ICircuitResponse Execute(ICircuitInfoQuery query);
    }
}