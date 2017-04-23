using System;
using System.Collections.Generic;
using System.Text;
using ErgastApi.Attributes;
using ErgastApi.Enums;
using ErgastApi.Interfaces;
using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Methods;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Models
{
    public class Query :
        IFormattable,
        IQuery,
        ILimitedQuery, IOffsetQuery, ILimitedOffsetQuery,
        IEmptyQuery,
        ICircuitsQuery,
        IConstructorsQuery,
        IConstructorStandingsQuery,
        IDriversQuery,
        IDriverStandingsQuery,
        IFastestLapQuery,
        IFinishingStatusQuery,
        IGridQuery,
        ILapTimesQuery,
        IResultsQuery,
        IRoundQuery,
        ISeasonQuery
    {
        public Query()
        {

        }

        public Query(Query query)
        {
            UsedTypes = new HashSet<Type>(query.UsedTypes);
            Builder = new StringBuilder(query.Builder.ToString());
            LimitValue = query.LimitValue;
            OffsetValue = query.OffsetValue;
        }

        // TODO: Implement default limit/offset if not set otherwise - either here or on QueryBuilder

        private ISet<Type> UsedTypes { get; } = new HashSet<Type>();

        private StringBuilder Builder { get; } = new StringBuilder();

        private int? LimitValue { get; set; }

        private int? OffsetValue { get; set; }

        public string Compile()
        {
            var url = new StringBuilder(Builder.ToString());
            url.Append(".json");

            if (LimitValue > 0)
                url.Append($"?limit={LimitValue}");

            if (OffsetValue > 0)
            {
                url.Append(LimitValue > 0 ? "&" : "?");
                url.Append($"offset={OffsetValue}");
            }

            return url.ToString();
        }

        public override string ToString() => Compile();

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Compile();
        }

        public Query Add<T>() => Add<T>(null);

        public Query Add<T>(int value) => Add<T>(value.ToString());

        // TODO: Make internal or check that T actually has an id attribute
        public Query Add<T>(string value)
        {
            return new Query(this).AddInternal<T>(value);
        }

        internal Query AddInternal<T>(string value)
        {
            // TODO: Exception message/type
            if (!UsedTypes.Add(typeof(T)))
                throw new Exception("Cannot add the same type more than once!");

            var id = typeof(T).GetId();

            if (!string.IsNullOrEmpty(id))
                Builder.AppendFormat("/{0}", id);

            if (!string.IsNullOrEmpty(value))
                Builder.AppendFormat("/{0}", value);

            return this;
        }

        public ILimitedQuery Limit(int limit)
        {
            return new Query(this) {LimitValue = limit};
        }

        public IOffsetQuery Offset(int offset)
        {
            return new Query(this) { OffsetValue = offset };
        }

        ILimitedOffsetQuery IOffsetQuery.Limit(int limit)
        {
            return new Query(this) { LimitValue = limit };
        }

        ILimitedOffsetQuery ILimitedQuery.Offset(int offset)
        {
            return new Query(this) { OffsetValue = offset };
        }

        public IFastestLapQuery FastestLap(int rank) => Add<IFastestLap>(rank);

        public IGridQuery Grid(int startingPosition) => Add<IGrid>(startingPosition);

        public IQuery Seasons() => Add<ISeasonsFilter>();

        public ISeasonQuery Season(int season) => Add<ISeason>(season);

        public ISeasonQuery CurrentSeason => Add<ISeason>("current");

        public IRoundQuery Round(int round) => Add<IRound>(round);

        public IRoundQuery LastRound => Add<IRound>("last");

        public IRoundQuery NextRound => Add<IRound>("next");

        public IQuery Circuits() => Add<ICircuitsFilter>();

        public ICircuitsQuery Circuits(string circuitId) => Add<ICircuits>(circuitId);

        public ICircuitsQuery Circuits(Circuit circuit) => Circuits(circuit.GetEnumId());

        public IQuery Drivers() => Add<IDriversFilter>();

        public IDriversQuery Drivers(string driverId) => Add<IDrivers>(driverId);

        public IDriversQuery Drivers(Driver driver) => Drivers(driver.GetEnumId());

        public IQuery Constructors() => Add<IConstructorsFilter>();

        public IConstructorsQuery Constructors(string constructorId) => Add<IConstructors>(constructorId);

        public IConstructorsQuery Constructors(Constructor constructor) => Constructors(constructor.GetEnumId());

        IResultsQuery IResults.Results() => Add<IResults>();

        IResultsQuery IResults.Results(int position) => Add<IResults>(position);

        IQuery IResultsFilter.Results() => Add<IResults>();

        IQuery IResultsFilter.Results(int position) => Add<IResults>(position);

        public IQuery Status() => Add<IFinishingStatusFilter>();

        public IFinishingStatusQuery Status(int statusId) => Add<IFinishingStatus>(statusId);

        public IFinishingStatusQuery Status(FinishingStatus status) => Add<IFinishingStatus>((int)status);

        // TODO: Separate IConstructorStandingsFilter infterface?
        public IQuery ConstructorStandings() => Add<IConstructorStandings>();

        public IConstructorStandingsQuery ConstructorStandings(int position) => Add<IConstructorStandings>(position);

        // TODO: Separate IDriverStandingsFilter infterface?
        public IQuery DriverStandings() => Add<IDriverStandings>();

        public IDriverStandingsQuery DriverStandings(int position) => Add<IDriverStandings>(position);

        public IQuery PitStops() => Add<IPitStopsFilter>();

        public IQuery PitStops(int stopNumber) => Add<IPitStopsFilter>(stopNumber);
    }
}
