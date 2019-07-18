using System;
using ErgastApi.Requests;

namespace ErgastApi.Tests
{
    internal static class HelperExtensions
    {
        public static void SetNonNullValue(this IErgastRequest request, string propertyName)
        {
            var property = request.GetType().GetProperty(propertyName);
            var propertyType = property.PropertyType;

            object value = null;

            var underlyingType = Nullable.GetUnderlyingType(propertyType);
            if (underlyingType != null)
            {
                value = Activator.CreateInstance(underlyingType);
            }
            else if (propertyType == typeof(string))
            {
                value = "";
            }
            else
            {
                try
                {
                    value = Activator.CreateInstance(propertyType);
                }
                catch
                {
                    // Ignore
                }
            }

            if (value == null)
                throw new InvalidOperationException("Property type not handled to get a non-null value");

            property.SetValue(request, value);
        }
    }
}
