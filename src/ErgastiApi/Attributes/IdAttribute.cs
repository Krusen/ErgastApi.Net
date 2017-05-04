using System;
using System.Linq;
using System.Reflection;
using ErgastApi.Extensions;

namespace ErgastApi.Attributes
{
    // TODO: Maybe rename this to ErgastId
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class IdAttribute : Attribute
    {
        public string Id { get; }

        public IdAttribute(string id)
        {
            Id = id;
        }
    }

    public static class IdExtensions
    {
        // TODO: Maybe rename methods
        internal static string GetId(this Type type)
        {
            return type.GetCustomAttribute<IdAttribute>().Id;
        }

        internal static string GetEnumId<TEnum>(this TEnum value)
            where TEnum : struct, IConvertible
        {
            return value.GetType()
                .GetMember(value.ToString())
                .First()
                .GetCustomAttribute<IdAttribute>()
                .Id;
        }
    }
}