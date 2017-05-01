using System;

namespace ErgastApi.Requests.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryDependencyAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public QueryDependencyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
