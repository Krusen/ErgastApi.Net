using System;
using ErgastApi.Client.Attributes;
using ErgastApi.Ids;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    // ReSharper disable once UnusedTypeParameter
    /// <summary>
    /// Base request class that contains properties for paging and limiting results to a season and/or round.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class ErgastRequest<TResponse> : IErgastRequest where TResponse : ErgastResponse
    {
        private int? _limit;
        private int? _offset;

        /// <summary>
        /// The number of results to return. Must be between 1 and 1000.
        /// Default value if not specified is 30.
        /// The <see cref="Page"/> method can be used for easier paging.
        /// </summary>
        public int? Limit
        {
            get => _limit;
            set
            {
                if (value < 0 || value > 1000)
                    throw new ArgumentOutOfRangeException(nameof(Limit), "Limit cannot be less than 0 or greater than 1000. Actual value: " + value);

                _limit = value;
            }
        }

        /// <summary>
        /// The offset to start from, used for paging the results together with <see cref="Limit"/>.
        /// The <see cref="Page"/> method can be used for easier paging.
        /// </summary>
        public int? Offset
        {
            get => _offset;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Offset), "Offset cannot be lower than 0");

                _offset = value;
            }
        }

        /// <summary>
        /// Limits the results to the specified season (year).
        /// Use <see cref="Seasons.Current"/> for current season.
        /// </summary>
        [UrlSegment(Order = 1)]
        public virtual string Season { get; set; }

        /// <summary>
        /// Limits the results to the specified round (number).
        /// Use <see cref="Rounds.Last"/> or <see cref="Rounds.Next"/> for the either last or next round.
        /// If this is specified <see cref="Season"/> must also be specified.
        /// </summary>
        [UrlSegment(Order = 2)]
        public virtual string Round { get; set; }

        /// <summary>
        /// Limits the results to the specified driver.
        /// The static <see cref="Drivers"/> class contains the IDs for most recent and popular drivers.
        /// </summary>
        [UrlSegment("drivers")]
        public virtual string DriverId { get; set; }

        /// <summary>
        /// Convenience method used for paging. Sets the limit and offset values for you.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        public virtual void Page(int page, int pageSize)
        {
            if (page < 1)
                throw new ArgumentOutOfRangeException(nameof(page), "Page number cannot be lower than 1");

            if (pageSize < 0 || pageSize > 1000)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size cannot be less than 0 or greater than 1000. Actual value: " + pageSize);

            Limit = pageSize;
            Offset = (page - 1) * pageSize;
        }
    }
}
