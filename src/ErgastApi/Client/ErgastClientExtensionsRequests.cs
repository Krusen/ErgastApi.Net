using System.Threading;
using System.Threading.Tasks;
using ErgastApi.Requests;
using ErgastApi.Responses;
using ErgastApi.Responses.Models;

namespace ErgastApi.Client
{
    /// <summary>
    /// Extensions to make the API easier to explore through intellisense
    /// by showing the different kinds of requests along with their documentation.
    /// </summary>
    public static class ErgastClientExtensionsRequests
    {
        /// <summary>
        /// Get a response with a list of circuits matching the request.
        /// </summary>
        public static Task<CircuitResponse> GetResponseAsync(this IErgastClient client, CircuitInfoRequest request)
            => client.GetResponseAsync(request, CancellationToken.None);

        /// <summary>
        /// Get a response with a list of constructors matching the request.
        /// </summary>
        public static Task<ConstructorResponse> GetResponseAsync(this IErgastClient client, ConstructorInfoRequest request)
            => client.GetResponseAsync(request, CancellationToken.None);

        /// <summary>
        /// Get a response with a list of constructor standings (WCC - World Constructors' Championship) matching the request.
        /// </summary>
        public static Task<ConstructorStandingsResponse> GetResponseAsync(this IErgastClient client, ConstructorStandingsRequest request)
            => client.GetResponseAsync(request, CancellationToken.None);

        /// <summary>
        /// Get a response with a list of drivers matching the request.
        /// </summary>
        public static Task<DriverResponse> GetResponseAsync(this IErgastClient client, DriverInfoRequest request)
            => client.GetResponseAsync(request, CancellationToken.None);

        /// <summary>
        /// Get a response with a list of driver standings (WDC - World Drivers' Championship) matching the request.
        /// </summary>
        public static Task<DriverStandingsResponse> GetResponseAsync(this IErgastClient client, DriverStandingsRequest request)
            => client.GetResponseAsync(request, CancellationToken.None);

        /// <summary>
        /// Get a response with a list of drivers' finishing status
        /// (<see cref="FinishingStatusId.Finished"/>, <see cref="FinishingStatusId.Clutch"/>,
        /// <see cref="FinishingStatusId.Collision"/>, <see cref="FinishingStatusId.Engine"/> etc.)
        /// matching the request.
        /// </summary>
        public static Task<FinishingStatusResponse> GetResponseAsync(this IErgastClient client, FinishingStatusRequest request)
            => client.GetResponseAsync(request, CancellationToken.None);

        /// <summary>
        /// Get a response with a list of races with lap times matching the request.
        /// </summary>
        public static Task<LapTimesResponse> GetResponseAsync(this IErgastClient client, LapTimesRequest request)
            => client.GetResponseAsync(request, CancellationToken.None);

        /// <summary>
        /// Get a response with races with pit stop information matching the request.
        /// </summary>
        public static Task<PitStopsResponse> GetResponseAsync(this IErgastClient client, PitStopsRequest request)
            => client.GetResponseAsync(request, CancellationToken.None);

        /// <summary>
        /// Get a response with a list of qualifying results matching the request.
        /// </summary>
        public static Task<QualifyingResultsResponse> GetResponseAsync(this IErgastClient client, QualifyingResultsRequest request)
            => client.GetResponseAsync(request, CancellationToken.None);

        /// <summary>
        /// Get a response with a list of races matching the request.
        /// </summary>
        public static Task<RaceListResponse> GetResponseAsync(this IErgastClient client, RaceListRequest request)
            => client.GetResponseAsync(request, CancellationToken.None);

        /// <summary>
        /// Get a response with a list of races with race results matching the request.
        /// </summary>
        public static Task<RaceResultsResponse> GetResponseAsync(this IErgastClient client, RaceResultsRequest request)
            => client.GetResponseAsync(request, CancellationToken.None);

        /// <summary>
        /// Get a response with a list of seasons matching the request.
        /// </summary>
        public static Task<SeasonResponse> GetResponseAsync(this IErgastClient client, SeasonListRequest request)
            => client.GetResponseAsync(request, CancellationToken.None);
    }
}
