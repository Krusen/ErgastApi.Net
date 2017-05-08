using System;

namespace ErgastApi.Client
{
    public class UrlSegmentInfo : IComparable<UrlSegmentInfo>
    {
        public int Order { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public bool IsTerminator { get; set; }

        public int CompareTo(UrlSegmentInfo other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            // Sort '0' (i.e. not set) higher than anything else
            if (Order == 0) return 1;

            return Order.CompareTo(other.Order);
        }
    }
}