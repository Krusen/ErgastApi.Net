using System;

namespace ErgastApi.Queries
{
    public class MethodCall : IComparable<MethodCall>
    {
        public int Order { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public bool IsTerminator { get; set; }

        public int CompareTo(MethodCall other)
        {
            if (Object.ReferenceEquals(this, other)) return 0;
            if (Object.ReferenceEquals(null, other)) return 1;

            // Sort '0' (i.e. not set) higher than anything else
            if (Order == 0) return 1;

            return Order.CompareTo(other.Order);
        }
    }
}