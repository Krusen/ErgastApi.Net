using System;

namespace ErgastApi.Requests.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UrlSegmentDependencyAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public UrlSegmentDependencyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
