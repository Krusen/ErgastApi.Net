using System;

namespace ErgastApi.Queries
{
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryTerminatorAttribute : Attribute
    {
    }
}