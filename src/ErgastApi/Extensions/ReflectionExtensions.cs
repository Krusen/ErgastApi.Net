using System;

namespace ErgastApi.Extensions
{
    internal static class ReflectionExtensions
    {
        internal static bool IsEnum(this Type type)
        {
            return type.IsEnum;
        }
    }
}
