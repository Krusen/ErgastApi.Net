using System;

namespace ErgastApi.Queries
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
