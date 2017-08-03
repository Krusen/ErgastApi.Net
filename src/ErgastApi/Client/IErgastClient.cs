using System.Threading.Tasks;
using ErgastApi.Requests;
using ErgastApi.Responses;

namespace ErgastApi.Client
{
    public interface IErgastClient
    {
        Task<T> GetResponseAsync<T>(ErgastRequest<T> request) where T : ErgastResponse;
    }
}