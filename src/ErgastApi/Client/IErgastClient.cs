using System.Threading.Tasks;
using ErgastApi.Requests;
using ErgastApi.Responses;

namespace ErgastApi.Client
{
    public interface IErgastClient
    {
        Task<T> ExecuteAsync<T>(ErgastRequest<T> request) where T : ErgastResponse;
    }
}