using System;

namespace ErgastApi.Client.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UrlSegmentAttribute : Attribute
    {
        /// <summary>
        /// "Hack" as nullables can't be used with attributes
        /// </summary>
        internal int? NullableOrder { get; set; }

        public int Order
        {
            get => NullableOrder ?? default(int);
            set => NullableOrder = value;
        }

        public string SegmentName { get; set; }

        public UrlSegmentAttribute()
        {
        }

        public UrlSegmentAttribute(string segmentName)
        {
            SegmentName = segmentName;
        }
    }
}