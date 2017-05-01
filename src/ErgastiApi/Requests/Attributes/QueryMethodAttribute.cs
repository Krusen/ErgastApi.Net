using System;

namespace ErgastApi.Requests.Attributes
{
    // TODO: Implement QueryDependency attribute in QueryBuilder
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryMethodAttribute : Attribute
    {
        public int Order { get; set; }

        public string MethodName { get; set; }

        public QueryMethodAttribute()
        {
        }

        public QueryMethodAttribute(string methodName)
        {
            MethodName = methodName;
        }
    }
}