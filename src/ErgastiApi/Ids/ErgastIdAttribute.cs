using System;
using System.Linq;
using System.Reflection;
using ErgastApi.Extensions;

namespace ErgastApi.Ids
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class ErgastIdAttribute : Attribute
    {
        public string Id { get; }

        public ErgastIdAttribute(string id)
        {
            Id = id;
        }
    }

    public static class IdExtensions
    {
        // TODO: Maybe rename methods
        internal static string GetId(this Type type)
        {
            return type.GetCustomAttribute<ErgastIdAttribute>().Id;
        }

        internal static string GetEnumId<TEnum>(this TEnum value)
            where TEnum : struct, IConvertible
        {
            return value.GetType()
                .GetMember(value.ToString())
                .First()
                .GetCustomAttribute<ErgastIdAttribute>()
                .Id;
        }
    }
}