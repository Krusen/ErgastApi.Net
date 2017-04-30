
using System.Threading.Tasks;
using ErgastApi.Queries.Standard;
using ErgastApi.Responses;

namespace ErgastApi
{
    public interface IErgastApi
    {
        // TODO: Sync methods?
        // TODO: Rename GetResponseAsync()?
        Task<IDriverResponse> ExecuteAsync(IDriverInfoQuery query);

        //IConstructorResponse Execute(IConstructorInfoQuery query);

        //ICircuitResponse Execute(ICircuitInfoQuery query);
    }
}