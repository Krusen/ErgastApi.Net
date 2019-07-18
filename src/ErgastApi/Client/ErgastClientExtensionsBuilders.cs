using System;
using System.Threading;
using System.Threading.Tasks;
using ErgastApi.Builders;
using ErgastApi.Responses;

namespace ErgastApi.Client
{
    /// <summary>
    /// Extensions with fluent request builders to make it easier and simpler to work with.
    /// </summary>
    public static class ErgastClientExtensionsBuilders
    {
        /// <summary>
        /// Get a response with circuits matching the request.
        /// The request is configured using the request builder's fluent API.
        /// </summary>
        public static Task<CircuitResponse> GetCircuitResponseAsync(this IErgastClient client, Action<CircuitInfoRequestBuilder> config)
            => GetCircuitResponseAsync(client, config, CancellationToken.None);

        /// <inheritdoc cref="GetCircuitResponseAsync(IErgastClient,Action{CircuitInfoRequestBuilder})"/>
        public static Task<CircuitResponse> GetCircuitResponseAsync(this IErgastClient client,
            Action<CircuitInfoRequestBuilder> config, CancellationToken token)
        {
            var builder = new CircuitInfoRequestBuilder();
            config(builder);
            return client.GetResponseAsync(builder.Request, token);
        }

        /// <summary>
        /// Get a response with constructors matching the request.
        /// The request is configured using the request builder's fluent API.
        /// </summary>
        public static Task<ConstructorResponse> GetConstructorResponseAsync(this IErgastClient client, Action<ConstructorInfoRequestBuilder> config)
            => GetConstructorResponseAsync(client, config, CancellationToken.None);

        /// <inheritdoc cref="GetConstructorResponseAsync(IErgastClient,Action{ConstructorInfoRequestBuilder})"/>
        public static Task<ConstructorResponse> GetConstructorResponseAsync(this IErgastClient client,
            Action<ConstructorInfoRequestBuilder> config, CancellationToken token)
        {
            var builder = new ConstructorInfoRequestBuilder();
            config(builder);
            return client.GetResponseAsync(builder.Request, token);
        }

        /// <summary>
        /// Get a response with constructor standings (WCC) matching the request.
        /// The request is configured using the request builder's fluent API.
        /// </summary>
        public static Task<ConstructorStandingsResponse> GetConstructorStandingsResponseAsync(this IErgastClient client, Action<ConstructorStandingsRequestBuilder> config)
            => GetConstructorStandingsResponseAsync(client, config, CancellationToken.None);

        /// <inheritdoc cref="GetConstructorStandingsResponseAsync(IErgastClient,Action{ConstructorStandingsRequestBuilder})"/>
        public static Task<ConstructorStandingsResponse> GetConstructorStandingsResponseAsync(this IErgastClient client,
            Action<ConstructorStandingsRequestBuilder> config, CancellationToken token)
        {
            var builder = new ConstructorStandingsRequestBuilder();
            config(builder);
            return client.GetResponseAsync(builder.Request, token);
        }

        /// <summary>
        /// Get a response with drivers matching the request.
        /// The request is configured using the request builder's fluent API.
        /// </summary>
        public static Task<DriverResponse> GetDriverResponseAsync(this IErgastClient client, Action<DriverInfoRequestBuilder> config)
            => GetDriverResponseAsync(client, config, CancellationToken.None);

        /// <inheritdoc cref="GetDriverResponseAsync(IErgastClient,Action{DriverInfoRequestBuilder})"/>
        public static Task<DriverResponse> GetDriverResponseAsync(this IErgastClient client,
            Action<DriverInfoRequestBuilder> config, CancellationToken token)
        {
            var builder = new DriverInfoRequestBuilder();
            config(builder);
            return client.GetResponseAsync(builder.Request, token);
        }

        /// <summary>
        /// Get a response with driver standings (WDC) matching the request.
        /// The request is configured using the request builder's fluent API.
        /// </summary>
        public static Task<DriverStandingsResponse> GetDriverStandingsResponseAsync(this IErgastClient client, Action<DriverStandingsRequestBuilder> config)
            => GetDriverStandingsResponseAsync(client, config, CancellationToken.None);

        /// <inheritdoc cref="GetDriverStandingsResponseAsync(IErgastClient,Action{DriverStandingsRequestBuilder})"/>
        public static Task<DriverStandingsResponse> GetDriverStandingsResponseAsync(this IErgastClient client,
            Action<DriverStandingsRequestBuilder> config, CancellationToken token)
        {
            var builder = new DriverStandingsRequestBuilder();
            config(builder);
            return client.GetResponseAsync(builder.Request, token);
        }

        /// <summary>
        /// Get a response with drivers' finishing status matching the request.
        /// The request is configured using the request builder's fluent API.
        /// </summary>
        public static Task<FinishingStatusResponse> GetFinishingStatusResponseAsync(this IErgastClient client, Action<FinishingStatusRequestBuilder> config)
            => GetFinishingStatusResponseAsync(client, config, CancellationToken.None);

        /// <inheritdoc cref="GetFinishingStatusResponseAsync(IErgastClient,Action{FinishingStatusRequestBuilder})"/>
        public static Task<FinishingStatusResponse> GetFinishingStatusResponseAsync(this IErgastClient client,
            Action<FinishingStatusRequestBuilder> config, CancellationToken token)
        {
            var builder = new FinishingStatusRequestBuilder();
            config(builder);
            return client.GetResponseAsync(builder.Request, token);
        }

        /// <summary>
        /// Get a response with a list of races with lap times matching the request.
        /// The request is configured using the request builder's fluent API.
        /// </summary>
        public static Task<LapTimesResponse> GetLapTimesResponseAsync(this IErgastClient client, Action<LapTimesRequestBuilder> config)
            => GetLapTimesResponseAsync(client, config, CancellationToken.None);

        /// <inheritdoc cref="GetLapTimesResponseAsync(IErgastClient,Action{LapTimesRequestBuilder})"/>
        public static Task<LapTimesResponse> GetLapTimesResponseAsync(this IErgastClient client,
            Action<LapTimesRequestBuilder> config, CancellationToken token)
        {
            var builder = new LapTimesRequestBuilder();
            config(builder);
            return client.GetResponseAsync(builder.Request, token);
        }

        /// <summary>
        /// Get a response with a list of races with pit stop info matching the request.
        /// The request is configured using the request builder's fluent API.
        /// </summary>
        public static Task<PitStopsResponse> GetPitStopsResponseAsync(this IErgastClient client, Action<PitStopsRequestBuilder> config)
            => GetPitStopsResponseAsync(client, config, CancellationToken.None);

        /// <inheritdoc cref="GetPitStopsResponseAsync(IErgastClient,Action{PitStopsRequestBuilder})"/>
        public static Task<PitStopsResponse> GetPitStopsResponseAsync(this IErgastClient client,
            Action<PitStopsRequestBuilder> config, CancellationToken token)
        {
            var builder = new PitStopsRequestBuilder();
            config(builder);
            return client.GetResponseAsync(builder.Request, token);
        }

        /// <summary>
        /// Get a response with qualifying results matching the request.
        /// The request is configured using the request builder's fluent API.
        /// </summary>
        public static Task<QualifyingResultsResponse> GetQualifyingResultsResponseAsync(this IErgastClient client, Action<QualifyingResultsRequestBuilder> config)
            => GetQualifyingResultsResponseAsync(client, config, CancellationToken.None);

        /// <inheritdoc cref="GetQualifyingResultsResponseAsync(IErgastClient,Action{QualifyingResultsRequestBuilder})"/>
        public static Task<QualifyingResultsResponse> GetQualifyingResultsResponseAsync(this IErgastClient client,
            Action<QualifyingResultsRequestBuilder> config, CancellationToken token)
        {
            var builder = new QualifyingResultsRequestBuilder();
            config(builder);
            return client.GetResponseAsync(builder.Request, token);
        }

        /// <summary>
        /// Get a response with a list of races matching the request.
        /// The request is configured using the request builder's fluent API.
        /// </summary>
        public static Task<RaceListResponse> GetRaceListResponseAsync(this IErgastClient client, Action<RaceListRequestBuilder> config)
            => GetRaceListResponseAsync(client, config, CancellationToken.None);

        /// <inheritdoc cref="GetRaceListResponseAsync(IErgastClient,Action{RaceListRequestBuilder})"/>
        public static Task<RaceListResponse> GetRaceListResponseAsync(this IErgastClient client,
            Action<RaceListRequestBuilder> config, CancellationToken token)
        {
            var builder = new RaceListRequestBuilder();
            config(builder);
            return client.GetResponseAsync(builder.Request, token);
        }

        /// <summary>
        /// Get a response with race results matching the request.
        /// The request is configured using the request builder's fluent API.
        /// </summary>
        public static Task<RaceResultsResponse> GetRaceResultsResponseAsync(this IErgastClient client, Action<RaceResultsRequestBuilder> config)
            => GetRaceResultsResponseAsync(client, config, CancellationToken.None);

        /// <inheritdoc cref="GetRaceResultsResponseAsync(IErgastClient,Action{RaceResultsRequestBuilder})"/>
        public static Task<RaceResultsResponse> GetRaceResultsResponseAsync(this IErgastClient client,
            Action<RaceResultsRequestBuilder> config, CancellationToken token)
        {
            var builder = new RaceResultsRequestBuilder();
            config(builder);
            return client.GetResponseAsync(builder.Request, token);
        }

        /// <summary>
        /// Get a response with seasons matching the request.
        /// The request is configured using the request builder's fluent API.
        /// </summary>
        public static Task<SeasonResponse> GetSeasonResponseAsync(this IErgastClient client, Action<SeasonListRequestBuilder> config)
            => GetSeasonResponseAsync(client, config, CancellationToken.None);

        /// <inheritdoc cref="GetSeasonResponseAsync(IErgastClient,Action{SeasonListRequestBuilder})"/>
        public static Task<SeasonResponse> GetSeasonResponseAsync(this IErgastClient client,
            Action<SeasonListRequestBuilder> config, CancellationToken token)
        {
            var builder = new SeasonListRequestBuilder();
            config(builder);
            return client.GetResponseAsync(builder.Request, token);
        }
    }
}
