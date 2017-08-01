using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ErgastApi.Client.Attributes;
using ErgastApi.Requests;

namespace ErgastApi.Client
{
    public class UrlBuilder : IUrlBuilder
    {
        public string Build(IErgastRequest request)
        {
            var segments = GetSegments(request);

            var url = "";
            foreach (var segment in segments)
            {
                if (segment.Name != null)
                    url += $"/{segment.Name}";

                if (segment.Value != null)
                    url += $"/{segment.Value}";
            }

            url += ".json";

            if (request.Limit != null)
                url += "?limit=" + request.Limit;

            if (request.Offset != null)
            {
                url += request.Limit == null ? "?" : "&";
                url += "offset=" + request.Offset;
            }

            return url;
        }

        private static IList<UrlSegmentInfo> GetSegments(IErgastRequest request)
        {
            var segments = new List<UrlSegmentInfo>();
            var properties = request.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var prop in properties)
            {
                var urlSegment = prop.GetCustomAttributes<UrlSegmentAttribute>(true).FirstOrDefault();
                var urlTerminator = prop.GetCustomAttributes<UrlTerminatorAttribute>(true).FirstOrDefault();
                var urlDependencies = prop.GetCustomAttributes<UrlSegmentDependencyAttribute>(true);

                if (urlSegment == null)
                    continue;

                // TODO: Expand UrlSegmentInfo with more info like PropertyInfo etc.

                var segment = new UrlSegmentInfo
                {
                    Order = NormalizeOrder(urlSegment.Order),
                    PropertyName = prop.Name,
                    Name = urlSegment.SegmentName,
                    Value = GetSegmentValue(prop, request),
                    IsTerminator = urlTerminator != null,
                    DependentPropertyNames = urlDependencies.Select(x => x.PropertyName)
                };

                if (segment.Value == null && !segment.IsTerminator)
                    continue;

                segments.Add(segment);
            }

            EnsureDependencies(segments);

            segments.Sort();

            return segments;
        }

        private static void EnsureDependencies(IList<UrlSegmentInfo> segments)
        {
            var valueMap = segments.ToDictionary(x => x.PropertyName, x => x.Value);

            foreach (var segment in segments)
            foreach (var propertyName in segment.DependentPropertyNames)
            {
                valueMap.TryGetValue(propertyName, out string value);
                if (value == null)
                {
                    // TODO: Custom exception? Improve exception message?
                    throw new Exception($"Invalid request. '{segment.PropertyName}' depends on '{propertyName}' but it is null.");
                }
            }
        }

        private static string GetSegmentValue(PropertyInfo property, IErgastRequest request)
        {
            var value = property.GetValue(request);
            if (value?.GetType().IsEnum == true)
                value = (int) value;

            return value?.ToString();
        }

        /// <summary>
        /// Converts 0 to null.
        /// </summary>
        private static int? NormalizeOrder(int order)
        {
            return order == 0 ? null : (int?) order;
        }
    }
}
