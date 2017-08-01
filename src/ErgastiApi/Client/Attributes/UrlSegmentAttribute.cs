using System;

namespace ErgastApi.Client.Attributes
{
    // TODO: Implement QueryDependency attribute in UrlBuilder
    [AttributeUsage(AttributeTargets.Property)]
    public class UrlSegmentAttribute : Attribute
    {
        public int Order { get; set; }

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