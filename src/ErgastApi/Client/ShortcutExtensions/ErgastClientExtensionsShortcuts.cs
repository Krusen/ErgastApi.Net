using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErgastApi.Builders;
using ErgastApi.Ids;
using ErgastApi.Requests;
using ErgastApi.Responses.Models;
using ErgastApi.Responses.Models.RaceInfo;
using ErgastApi.Responses.Models.Standings;

namespace ErgastApi.Client.ShortcutExtensions
{
    /// <summary>
    /// Shortcut methods for common requests to make it simpler and easier to explore the API.
    /// </summary>
    public static class ErgastClientExtensionsShortcuts
    {
        /// <summary>
        /// Get info about a specific circuit.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="circuitId">The ID of the circuit. Use the <see cref="Circuits"/> static class for the IDs of popular circuits.</param>
        public static Task<Circuit> GetCircuitAsync(this IErgastClient client, string circuitId)
            => GetCircuitAsync(client, circuitId, default(CancellationToken));

        /// <inheritdoc cref="GetCircuitAsync(ErgastApi.Client.IErgastClient,string)"/>
        public static async Task<Circuit> GetCircuitAsync(this IErgastClient client, string circuitId, CancellationToken token)
        {
            var request = new CircuitInfoRequest {CircuitId = circuitId};
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.Circuits.FirstOrDefault();
        }

        /// <summary>
        /// Get a list of circuits for a specific season or for all seasons (e.g. all circuits) by leaving <paramref name="season"/> as null.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="season">The season to get circuits for. Use <c>null</c> to get all circuits.</param>
        /// <param name="limit">The max number of results to return.</param>
        /// <param name="token"></param>
        public static async Task<IList<Circuit>> GetCircuitsAsync(this IErgastClient client,
            string season = Seasons.All, int? limit = 1000, CancellationToken token = default(CancellationToken))
        {
            var request = new CircuitInfoRequest {Season = season, Limit = limit};
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.Circuits;
        }

        /// <summary>
        /// Get info about a specific constructor.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="constructorId">The ID of the constructor. Use the <see cref="Constructors"/> static class for the IDs of popular constructors.</param>
        /// <param name="token"></param>
        public static async Task<Constructor> GetConstructorAsync(this IErgastClient client, string constructorId, CancellationToken token = default(CancellationToken))
        {
            var request = new ConstructorInfoRequest {ConstructorId = constructorId};
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.Constructors.FirstOrDefault();
        }

        /// <summary>
        /// Get a list of constructors in a specific season and optionally a specific round in the season.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="season">The season. Use <c>null</c> to get all constructors.</param>
        /// <param name="round">The round of the season. Use <c>null</c> for all rounds.</param>
        /// <param name="limit">The max number of results to return.</param>
        /// <param name="token"></param>
        public static async Task<Constructor> GetConstructorsAsync(this IErgastClient client,
            string season = Seasons.All, string round = Rounds.All, int? limit = 1000, CancellationToken token = default(CancellationToken))
        {
            var request = new ConstructorInfoRequestBuilder().Season(season).Round(round).Limit(limit).Request;
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.Constructors.FirstOrDefault();
        }

        /// <summary>
        /// Get info about a specific driver.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="driverId">The ID of the driver. Use the <see cref="Drivers"/> static class for the IDs of popular drivers.</param>
        public static Task<Driver> GetDriverAsync(this IErgastClient client, string driverId)
            => GetDriverAsync(client, driverId, default(CancellationToken));

        /// <inheritdoc cref="GetDriverAsync(ErgastApi.Client.IErgastClient,string)"/>
        public static async Task<Driver> GetDriverAsync(this IErgastClient client, string driverId, CancellationToken token)
        {
            var request = new DriverInfoRequest {DriverId = driverId};
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.Drivers.FirstOrDefault();
        }

        /// <summary>
        /// Get a list of drivers in a specific season and optionally a specific round in the season.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="season">The season. Use <c>null</c> to get all drivers.</param>
        /// <param name="round">The round of the season. Use <c>null</c> for all rounds.</param>
        /// <param name="limit">The max number of results to return.</param>
        /// <param name="token"></param>
        public static async Task<IList<Driver>> GetDriversAsync(this IErgastClient client,
            string season = Seasons.All, string round = Rounds.All, int? limit = 1000, CancellationToken token = default(CancellationToken))
        {
            var request = new DriverInfoRequestBuilder().Season(season).Round(round).Limit(limit).Request;
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.Drivers;
        }

        /// <summary>
        /// Get the driver standings (WDC) for a specific season and optionally at a specific round in the season.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="season">The season. Use <c>null</c> to get all results.</param>
        /// <param name="round">The round of the season. Use <c>null</c> for final results of the season.</param>
        /// <param name="limit">The max number of results to return.</param>
        /// <param name="token"></param>
        public static async Task<DriverStandingsList> GetDriverStandingsAsync(this IErgastClient client,
            string season = Seasons.Current, string round = Rounds.Last, int? limit = 1000, CancellationToken token = default(CancellationToken))
        {
            var request = new DriverStandingsRequestBuilder().Season(season).Round(round).Limit(limit).Request;
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.StandingsLists.FirstOrDefault();
        }

        /// <summary>
        /// Get the constructor standings (WCC) for a specific season and optionally at a specific round in the season.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="season">The season. Use <c>null</c> to get all results.</param>
        /// <param name="round">The round of the season. Use <c>null</c> for final results of the season.</param>
        /// <param name="limit">The max number of results to return.</param>
        /// <param name="token"></param>
        public static async Task<ConstructorStandingsList> GetConstructorStandingsAsync(this IErgastClient client,
            string season = Seasons.Current, string round = Rounds.Last, int? limit = 1000, CancellationToken token = default(CancellationToken))
        {
            var request = new ConstructorStandingsRequestBuilder().Season(season).Round(round).Limit(limit).Request;
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.StandingsLists.FirstOrDefault();
        }

        /// <summary>
        /// Get qualifying results for a specific season and optionally a specific round in the season.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="season">The season. Use <c>null</c> to get all results.</param>
        /// <param name="round">The round of the season. Use <c>null</c> for all rounds.</param>
        /// <param name="limit">The max number of results to return.</param>
        /// <param name="token"></param>
        public static async Task<IList<RaceWithQualifyingResults>> GetQualifyingResultsAsync(this IErgastClient client,
            string season = Seasons.Current, string round = Rounds.Last, int? limit = 1000, CancellationToken token = default(CancellationToken))
        {
            var request = new QualifyingResultsRequestBuilder().Season(season).Round(round).Limit(limit).Request;
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.Races;
        }

        /// <summary>
        /// Get race results for a specific season and optionally a specific round in the season.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="season">The season. Use <c>null</c> to get all results.</param>
        /// <param name="round">The round of the season. Use <c>null</c> for all rounds.</param>
        /// <param name="limit">The max number of results to return.</param>
        /// <param name="token"></param>
        public static async Task<IList<RaceWithResults>> GetRaceResultsAsync(this IErgastClient client,
            string season = Seasons.Current, string round = Rounds.Last, int? limit = 1000, CancellationToken token = default(CancellationToken))
        {
            var request = new RaceResultsRequestBuilder().Season(season).Round(round).Limit(limit).Request;
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.Races;
        }

        /// <summary>
        /// Get a list of seasons where a driver participated.
        /// Optionally filter results to only include seasons where
        /// the driver finished in a specific position at the end of the season.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="driverId">The ID of the driver. Use the <see cref="Drivers"/> static class for the IDs of popular drivers.</param>
        /// <param name="driverStanding">The finishing position of the driver.</param>
        /// <param name="token"></param>
        public static async Task<IList<Season>> GetDriverSeasonsAsync(this IErgastClient client,
            string driverId, int? driverStanding = null, CancellationToken token = default(CancellationToken))
        {
            var request = new SeasonListRequestBuilder()
                .Driver(driverId)
                .DriverStanding(driverStanding)
                .Request;
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.Seasons;
        }

        /// <summary>
        /// Get a list of seasons where a constructor participated.
        /// Optionally filter results to only include seasons where
        /// the constructor finished in a specific position at the end of the season.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="constructorId">The ID of the constructor. Use the <see cref="Constructors"/> static class for the IDs of popular constructors.</param>
        /// <param name="constructorStanding">The finishing position of the constructor.</param>
        /// <param name="token"></param>
        public static async Task<IList<Season>> GetConstructorSeasonsAsync(this IErgastClient client,
            string constructorId, int? constructorStanding = null, CancellationToken token = default(CancellationToken))
        {
            var request = new SeasonListRequestBuilder()
                .Constructor(constructorId)
                .ConstructorStanding(constructorStanding)
                .Request;
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.Seasons;
        }

        /// <summary>
        /// Get a list of seasons where a driver drove for a specific constructor.
        /// Optionally filter results to only include seasons where
        /// the driver or constructor finished in a specific position at the end of the season.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="driverId">The ID of the driver. Use the <see cref="Drivers"/> static class for the IDs of popular drivers.</param>
        /// <param name="constructorId">The ID of the constructor. Use the <see cref="Constructors"/> static class for the IDs of popular constructors.</param>
        /// <param name="driverStanding">The finishing position of the driver.</param>
        /// <param name="constructorStanding">The finishing position of the constructor.</param>
        /// <param name="token"></param>
        public static async Task<IList<Season>> GetDriverConstructorSeasonsAsync(this IErgastClient client,
            string driverId, string constructorId, int? driverStanding = null, int? constructorStanding = null,
            CancellationToken token = default(CancellationToken))
        {
            var request = new SeasonListRequestBuilder()
                .Driver(driverId)
                .Constructor(constructorId)
                .DriverStanding(driverStanding)
                .ConstructorStanding(constructorStanding)
                .Request;
            var response = await client.GetResponseAsync(request, token).ConfigureAwait(false);
            return response.Seasons;
        }
    }
}
