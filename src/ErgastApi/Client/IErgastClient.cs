using System.Threading;
using System.Threading.Tasks;
using ErgastApi.Requests;
using ErgastApi.Responses;

namespace ErgastApi.Client
{
    public interface IErgastClient
    {
        /// <summary>
        /// Executes the request and returns a parsed response of type <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the returned response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <param name="cancellationToken"></param>
        Task<TResponse> GetResponseAsync<TResponse>(ErgastRequest<TResponse> request, CancellationToken cancellationToken)
            where TResponse : ErgastResponse;
    }
}