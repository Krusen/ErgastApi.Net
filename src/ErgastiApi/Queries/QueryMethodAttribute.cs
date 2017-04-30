using System;

namespace ErgastApi.Queries
{
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