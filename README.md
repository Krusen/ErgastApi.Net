# Ergast Developer API .NET Client (ErgastApiClient)

[![license](https://img.shields.io/badge/license-Unlicense-blue.svg)](https://github.com/Krusen/ErgastApi.Net/blob/master/LICENSE.md)
[![AppVeyor](https://ci.appveyor.com/api/projects/status/kaibsj29lcn9aqt1?svg=true)](https://ci.appveyor.com/project/Krusen/ergastapi-net)
[![Coverage](https://coveralls.io/repos/github/Krusen/ErgastApi.Net/badge.svg)](https://coveralls.io/github/Krusen/ErgastApi.Net)
[![CodeFactor](https://www.codefactor.io/repository/github/krusen/ergastapi.net/badge)](https://www.codefactor.io/repository/github/krusen/ergastapi.net)
[![NuGet](https://buildstats.info/nuget/ergastapiclient?includePreReleases=false)](https://www.nuget.org/packages/ErgastApiClient/)
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bhttps%3A%2F%2Fgithub.com%2FKrusen%2FErgastApi.Net.svg?type=shield)](https://app.fossa.io/projects/git%2Bhttps%3A%2F%2Fgithub.com%2FKrusen%2FErgastApi.Net?ref=badge_shield)

This a C# library wrapping the Ergast Developer API (http://ergast.com/mrd).

The library makes it easy to explore and use the API and also takes care of caching the responses to minimize the load on API server.

The Ergast Developer API is an experimental web service which provides access a historical record of motor racing data for non-commercial purposes.
Please read the [terms and conditions of use](http://ergast.com/mrd/terms).

The API provides data for the Formula One series, from the beginning of the world championships in 1950.

Non-programmers can query the database using the [manual interface](http://ergast.com/mrd/query).

# Installation


Install the package **ErgastApiClient** from [NuGet](https://www.nuget.org/packages/ErgastApiClient/) 
or install it from the [Package Manager Console](https://docs.microsoft.com/da-dk/nuget/tools/package-manager-console):

```
PM> Install-Package ErgastApiClient
```

The latests builds can be found on the [MyGet feed](https://www.myget.org/feed/krusen/package/nuget/ErgastApiClient).

# Changes in V2

There has been made a few breaking changes for V2, but most users will likely not notice these.

[Click here](https://www.fuget.org/packages/ErgastApiClient/2.0.0/lib/netstandard2.0/diff/1.2.2/) for a full overview of changes made compared to v1.2.2.

#### Changed
 - Updated requests and their properties/filters to match what works with the API
 - Added speed conversion on `AverageSpeed` class

#### Added
 - Support for `CancellationToken`
 - Extension methods with request builders (fluent request configuration)
 - Extension methods with shortcuts for common requests
 - Conversion of speed from/to mph/kph on `AverageSpeed` class

#### Removed
 - Custom caching (`IErgastCache` and related code) in favor of [Polly](https://github.com/App-vNext/Polly)

# Usage

Simply create a client like this:

```C#
// Relevant imports
using ErgastApi.Client;
using ErgastApi.Ids;
using ErgastApi.Requests;

// The client should be stored and reused as it caches responses
var client = new ErgastClient();
```

You can explore the API through the methods on `client`.

`ErgastClient` has a base method `GetResponseAsync<T>(T request, CancellationToken token)` to execute requests, 
but there are also a lot of extensions methods which shows the possible request types and allows configuring the request through a fluent API.

```C#
// List of seasons where Alonso won the WDC and Ferrari got second in the WCC
var request = new SeasonListRequest
{
    // Drivers.FernandoAlonso is just a constant value of "alonso", his ID in the database
    DriverId = Drivers.FernandoAlonso,
    DriverStanding = 1,

    // Constructors.Ferrar is just a constant value of "ferrari", their ID in the database
    ConstructorId = Constructors.Ferrari,
    ConstructorStanding = 2
}
// CancellationToken is optional and can be left out 
// as there are overloaded extensions methods using CancellationToken.None
var response = await client.GetResponseAsync(request); 

// Same request using the fluent API
await client.GetSeasonResponseAsync(x => x.Driver("alonso").Constructor("ferrari").DriverStanding(1).ConstructorStanding(2));
```

There are extensions method with request builders using a fluent API for all request types:

```C#
Task<CircuitResponse> GetCircuitResponseAsync(Action<CircuitInfoRequestBuilder> config);
Task<ConstructorResponse> GetConstructorResponseAsync(Action<ConstructorInfoRequestBuilder> config);
Task<ConstructorStandingsResponse> GetConstructorStandingsResponseAsync(Action<ConstructorStandingsRequestBuilder> config);
Task<DriverResponse> GetDriverResponseAsync(Action<DriverInfoRequestBuilder> config);
Task<DriverStandingsResponse> GetDriverStandingsResponseAsync(Action<DriverStandingsRequestBuilder> config);
Task<FinishingStatusResponse> GetFinishingStatusResponseAsync(Action<FinishingStatusRequestBuilder> config);
Task<LapTimesResponse> GetLapTimesResponseAsync(Action<LapTimesRequestBuilder> config);
Task<PitStopsResponse> GetPitStopsResponseAsync(Action<PitStopsRequestBuilder> config);
Task<QualifyingResultsResponse> GetQualifyingResultsResponseAsync(Action<QualifyingResultsRequestBuilder> config);
Task<RaceListResponse> GetRaceListResponseAsync(Action<RaceListRequestBuilder> config);
Task<RaceResultsResponse> GetRaceResultsResponseAsync(Action<RaceResultsRequestBuilder> config);
Task<SeasonResponse> GetSeasonResponseAsync(Action<SeasonListRequestBuilder> config);

// + overloads with a CancellationToken parameter
```

There are also some "shortcut" extension methods, located in the `ErgastApi.Client.ShortcutExtensions` namespace.

These extension methods skips the response object and as such contain no information about paging or the request itself.

```C#
using ErgastApi.Client.ShortcutExtensions;

// Get info about Keving Magnussen
Driver driver = await client.GetDriverAsync(Drivers.KevinMagnussen);

// Get info about Spa-Francorchamps
Circuit circuit = await client.GetCircuitAsync("spa");

// Get a list of drivers in current season
IList<Driver> drivers = await client.GetDriversAsync(season: "current");

// Get the standings for the current season
DriverStandingsList standings = await client.GetDriverStandingsAsync();
```

These are all the shortcut extension methods:

```C#
Task<Circuit> GetCircuitAsync(string circuitId)
Task<Circuit> GetCircuitAsync(string circuitId, CancellationToken token)
Task<IList<Circuit>> GetCircuitsAsync(string season = null, int? limit = 1000, CancellationToken token = null)
Task<Constructor> GetConstructorAsync(string constructorId, CancellationToken token = null)
Task<Constructor> GetConstructorsAsync(string season = null, string round = null, int? limit = 1000, CancellationToken token = null)
Task<IList<Season>> GetConstructorSeasonsAsync(string constructorId, int? constructorStanding = null, CancellationToken token = null)
Task<ConstructorStandingsList> GetConstructorStandingsAsync(string season = "current", string round = "last", int? limit = 1000, CancellationToken token = null)
Task<Driver> GetDriverAsync(string driverId)
Task<Driver> GetDriverAsync(string driverId, CancellationToken token)
Task<IList<Season>> GetDriverConstructorSeasonsAsync(string driverId, string constructorId, int? driverStanding = null, int? constructorStanding = null, CancellationToken token = null)
Task<IList<Driver>> GetDriversAsync(string season = null, string round = null, int? limit = 1000, CancellationToken token = null)
Task<IList<Season>> GetDriverSeasonsAsync(string driverId, int? driverStanding = null, CancellationToken token = null)
Task<DriverStandingsList> GetDriverStandingsAsync(string season = "current", string round = "last", int? limit = 1000, CancellationToken token = null)
Task<IList<RaceWithQualifyingResults>> GetQualifyingResultsAsync(string season = "current", string round = "last", int? limit = 1000, CancellationToken token = null)
Task<IList<RaceWithResults>> GetRaceResultsAsync(string season = "current", string round = "last", int? limit = 1000, CancellationToken token = null)
```

## Request Types

Here is a list of all the specific request types and what information the response contains:

- `CircuitInfoRequest`
  - Circuit information like name and location
- `DriverInfoRequest`
  - Driver information like name, 3-letter code, date of birth etc.
- `ConstructorInfoRequest`
  - Information about a constructor like name and nationality
- `DriverStandingsRequest`, `ConstructorStandingsRequest`
  - WDC/WCC standings with position, points and wins
- `FinishingStatusRequest`
  - A list of finishing statuses and count of drivers with that status (e.g. Finished or reason for not finishing like Engine, Collision etc.)
- `LapTimesRequest`
  - A list of races with a list of lap times and the driver's position at the end of the lap
- `PitStopsRequest`
  - A list of races with a list of pit stop information like pit stop number, lap number, time of day and duration (in pit lane)
- `QualifyingResultsRequest`
  - A list of races with a list of qualifying results
- `RaceResultsRequest`
  - A list of races with a list of race results with information like starting position, finishing position, points, gap to winner, fastest lap etc.
- `RaceListRequest`
  - A list of races with information about circuit, race start time etc.
- `SeasonListRequest`
  - A list of seasons

## Driver, constructor and circuit IDs

Circuits, drivers and constructors have unique IDs in the Ergast database.

Some of them can be guessed or found through trial and error, e.g. `"alonso"` for Fernando Alonso and `"spa"` for Spa-Francorchamps.

There are static classes containing the IDs of popular and recent circuits, drivers and constructors:

```C#
using ErgastApi.Ids;

Drivers.KevinMagnussen;   // "kevin_magnussen"
Drivers.LewisHamilton;    // "hamilton"
Constructors.RedBull;     // "red_bull"
Circuits.PaulRicard;      // "ricard"
```

If the ID you are looking for is not listed there, then you will have to query the API with either
a `DriverInfoRequest`, `ConstructorInfoRequest` or `CircuitInfoRequest`.

Here is how you could find the ID of Fernando Alonso:

```C#
var response = await client.GetDriverResponseAsync(x => x.Limit(1000));
response.Drivers.Single(x => x.FullName == "Fernando Alonso").DriverId;
```

## Paging

The default limit on returned results is 30 and maximum allowed by the API is 1000 (but please use less if you can).

When getting responses like race results and qualifying results for severals rounds/circuits each 
driver result counts toward the limits, i.e. one race counts for 20 results in 2019 season (20 drivers).

Paging of results can be managed by setting the `Limit` and `Offset` parameters of a request manually, 
or by using the `Page(int page, int pageSize)` method on a request object or through the fluent API.

```C#
// Paging with Limit and Offset manually
var response = await client.GetRaceResultsResponseAsync(x => x.Season(Seasons.Current).Limit(5).Offset(10));
// Same result using the Page() method
var response = await client.GetRaceResultsResponseAsync(x => x.Season(Seasons.Current).Page(page: 3, pageSize: 5);
```

The response objects returned by `ErgastCleitn` contains the following information to help you with paging:

- `int Limit` and `int Offset` (the values used for the response)
- `int TotalResults`
- `int Page`
- `int TotalPages`
- `bool HasMorePages`

## Caching

`ErgastClient` uses [Polly](https://github.com/App-vNext/Polly) to cache responses (for 1 hour) 
to minimize the load on the API server. Requests are cached by the resulting URL.

You can change the Polly policy by setting `ErgastClient.PollyPolicy` to your own `IAsyncPolicy`
 if you want different caching or want to add a retry policy.

## Request Examples:

```C#
// List of seasons where Alonso won the WDC and Ferrari got second in the WCC
new SeasonListRequest
{
    DriverId = Drivers.FernandoAlonso,
    DriverStanding = 1,

    ConstructorId = Constructors.Ferrari,
    ConstructorStanding = 2
}

// List of races where Raikkonen retired because
// of engine problems while racing for Ferrari
new RaceListRequest
{
    DriverId = Drivers.KimiRaikkonen,
    ConstructorId = Constructors.Ferrari,
    FinishingStatus = FinishingStatusId.Engine
}

// Qualifying results from last round
new QualifyingResultsRequest
{
    Season = Seasons.Current,
    Round = Rounds.Last
}

// Driver standings after race 3 in 2018
new DriverStandingsRequest
{ 
    Season = "2018", 
    Round = "3"
}

// List of circuits where Hamilton got pole, won the race
// and set fastest lap time while racing for McLaren
new CircuitInfoRequest
{
    DriverId = Drivers.LewisHamilton,
    ConstructorId = Constructors.McLaren,
    QualifyingPosition = 1,
    FinishingPosition = 1,
    FastestLapRank = 1
}

// Drivers who have won the race at Baku
new DriverInfoRequest
{
    CircuitId = Circuits.Baku,
    FinishingPosition = 1
}
```

# TODOs

- Add helper methods for getting next/previous page
- Add more XML documentation for better intellisense
- Add more unit tests

# License
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bhttps%3A%2F%2Fgithub.com%2FKrusen%2FErgastApi.Net.svg?type=large)](https://app.fossa.io/projects/git%2Bhttps%3A%2F%2Fgithub.com%2FKrusen%2FErgastApi.Net?ref=badge_large)