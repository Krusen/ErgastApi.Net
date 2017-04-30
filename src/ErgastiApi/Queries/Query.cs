using System;
using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries
{
    public abstract class Query : IQuery
    {
        private int? _limit;
        private int? _offset;

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

        [QueryMethod(Order = 1)]
        public virtual int? Season { get; set; }

        // TODO: Require season to be not null
        [QueryMethod(Order = 2)]
        [QueryDependency(nameof(Season))]
        public virtual int? Round { get; set; }

        [QueryMethod("drivers")]
        public virtual string DriverId { get; set; }

        public void Page(int page, int pageSize)
        {
            if (page < 1)
                throw new ArgumentOutOfRangeException(nameof(page), "Page number cannot be lower than 1");

            if (pageSize < 0 || pageSize > 1000)
                throw new ArgumentOutOfRangeException(nameof(pageSize),"Page size cannot be less than 0 or greater than 1000. Actual value: " + pageSize);

            Limit = pageSize;
            Offset = (page - 1) * pageSize;
        }
    }
}