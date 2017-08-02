using System;
using System.Reflection;

namespace ErgastApi.Extensions
{
    public static class ReflectionExtensions
    {
        internal static T GetCustomAttribute<T>(this Type type) where T : Attribute
        {
            return type.GetTypeInfo().GetCustomAttribute<T>();
        }
    }
}
