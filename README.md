# Ergast Developer API .NET Client

[![license](https://img.shields.io/badge/license-Unlicense-blue.svg)](https://github.com/Krusen/ErgastApi.Net/blob/master/LICENSE.md)
[![AppVeyor](https://ci.appveyor.com/api/projects/status/kaibsj29lcn9aqt1?svg=true)](https://ci.appveyor.com/project/Krusen/ergastapi-net)
[![Coverage](https://coveralls.io/repos/github/Krusen/ErgastApi.Net/badge.svg)](https://coveralls.io/github/Krusen/ErgastApi.Net)
[![CodeFactor](https://www.codefactor.io/repository/github/krusen/ergastapi.net/badge)](https://www.codefactor.io/repository/github/krusen/ergastapi.net)
[![NuGet](https://buildstats.info/nuget/ergastapiclient?includePreReleases=false)](https://www.nuget.org/packages/ErgastApiClient/)
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bhttps%3A%2F%2Fgithub.com%2FKrusen%2FErgastApi.Net.svg?type=shield)](https://app.fossa.io/projects/git%2Bhttps%3A%2F%2Fgithub.com%2FKrusen%2FErgastApi.Net?ref=badge_shield)

This a C# library wrapping the Ergast Developer API (http://ergast.com/mrd).

The library makes it easy to explore and use the API and also takes care of caching the responses to minimize the load on API server.

he Ergast Developer API is an experimental web service which provides access a historical record of motor racing data for non-commercial purposes.
Please read the [terms and conditions of use](http://ergast.com/mrd/terms).

The API provides data for the Formula One series, from the beginning of the world championships in 1950.

Non-programmers can query the database using the [manual interface](http://ergast.com/mrd/query).

## Installation


Install the package **ErgastApiClient** from [NuGet](https://www.nuget.org/packages/ErgastApiClient/) 
or install it from the [Package Manager Console](https://docs.microsoft.com/da-dk/nuget/tools/package-manager-console):

```
PM> Install-Package ErgastApiClient
```


## Usage

The library is easy to use.

Start by creating an `ErgastClient`. Then create on of the request types and set parameters to narrow down your query.
Then execute the request throughe the client with the `GetResponseAsync(IErgastRequest)` method.

Below is an example of how to get the race results of the 11th race of the 2017 season.

```C#
// Relevant imports
using ErgastApi.Client;
using ErgastApi.Ids;
using ErgastApi.Requests;

// The client should be stored and reused during the lifetime of your application
var client = new ErgastClient();

// All request properties are optional (except 'Season' if 'Round' is set)
var request = new RaceResultsRequest
{
    Season = "2017",     // or Seasons.Current for current season
    Round = "11",        // or Rounds.Last or Rounds.Next for last or next round
    DriverId = "vettel", // or Drivers.SebastianVettel

    Limit = 30      // Limit the number of results returned
    Offset = 0      // Result offset (used for paging)
};

// RaceResultsRequest returns a RaceResultsResponse
// Other requests returns other response types
RaceResultsResponse response = await client.GetResponseAsync(request);
```

The following request types are available:

- Race & Results
  - `CircuitInfoRequest`
  - `ConstructorInfoRequest` 
  - `DriverInfoRequest`
  - `FinishingStatusRequest`
  - `QualifyingResultsRequest`
  - `RaceListRequest`
  - `RaceResultsRequest`
  - `SeasonListRequest`
- Standings
  - `ConstructorStandingsRequest`
  - `DriverStandingsRequest`
- Lap Times & Pit Stops
  - `LapTimesRequest`
  - `PitStopsRequest`

Here are some other examples:

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

// Driver standings after race 3 in 2017
new DriverStandingsRequest
{ 
    Season = "2017", 
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

### Driver, constructor and circuit IDs

Most current IDs are stored as constants in the `Drivers`, `Constructors` and `Circuits` static classes.

```C#
Drivers.SebastianVettel // "vettel"
Constructors.Ferrari    // "ferrari"
Circuits.Monza          // "monza"
```

If the ID you are looking for is not listed there, then you will have to query the API with either
a `DriverInfoRequest`, `ConstructorInfoRequest` or `CircuitInfoRequest`.

Here is how you could find the ID of Fernando Alonso:

```C#
// Get drivers in current season (leave out season to get a list of all drivers ever (requires paging))
var request = new DriverInfoRequest { Limit = 1000 }
var response = await client.GetResponseAsync(request);

response.Drivers.Single(x => x.FullName == "Fernando Alonso").DriverId;
```


### Paging

Some responses will have a lot of results. Every request type has two properties used for paging - `Limit` and `Offset`.

The `Limit` property allows you to limit the number of returned results.
The maximum value is 1000 but please use the smallest value that you can. If not set it defaults to 30.

The `Offset` property specifies an offset into the result set (i.e. start from this position).
If not set it defaults to zero.

The response object returned from `ErgastClient.GetResponseAsync()` contains the following information to help you with paging:

- `Limit` and `Offset` (the values used for the response)
- `TotalResults`
- `Page`
- `TotalPages`
- `HasMorePages`


### Caching

`ErgastClient` caches the response for all requests to minimize the load on the API server. Requests are cached by the resulting URL.

The default cache lifetime is one hour. You can change this by setting `client.Cache.CacheEntryLifetime` to a different `TimeSpan` value.

You can clear the cache by calling `client.Cache.Clear()`.


## TODOs

- Add helper methods for getting next/previous page
- Add more XML documentation for better intellisense
- Add more unit tests

## License
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bhttps%3A%2F%2Fgithub.com%2FKrusen%2FErgastApi.Net.svg?type=large)](https://app.fossa.io/projects/git%2Bhttps%3A%2F%2Fgithub.com%2FKrusen%2FErgastApi.Net?ref=badge_large)
