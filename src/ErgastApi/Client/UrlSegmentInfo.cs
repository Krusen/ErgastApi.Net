using System;
using System.Collections.Generic;

namespace ErgastApi.Client
{
    public class UrlSegmentInfo : IComparable<UrlSegmentInfo>
    {
        public int? Order { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public bool IsTerminator { get; set; }

        public int CompareTo(UrlSegmentInfo other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            var comparisons = new Func<UrlSegmentInfo, int>[]
            {
                CompareTerminator,
                CompareOrder,
                CompareName
            };

            foreach (var compareTo in comparisons)
            {
                var value = compareTo(other);
                if (value != 0)
                    return value;
            }

            return 0;
        }

        private int CompareTerminator(UrlSegmentInfo other)
        {
            if (IsTerminator) return 1;
            if (other.IsTerminator) return -1;
            return 0;
        }

        private int CompareOrder(UrlSegmentInfo other)
        {
            if (Order == null && other.Order == null) return 0;
            if (Order == null) return 1;
            if (other.Order == null) return -1;

            return Order.Value.CompareTo(other.Order.Value);
        }

        private int CompareName(UrlSegmentInfo other)
        {
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}