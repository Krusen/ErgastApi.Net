using System;

#if NETSTANDARD
using System.Reflection;
#endif

namespace ErgastApi.Extensions
{
    internal static class ReflectionExtensions
    {
        internal static bool IsEnum(this Type type)
        {
#if NETSTANDARD
            return type.GetTypeInfo().IsEnum;
#else
            return type.IsEnum;
#endif
        }
    }
}
