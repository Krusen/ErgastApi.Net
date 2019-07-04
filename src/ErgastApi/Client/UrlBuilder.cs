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
                var urlSegment = prop.GetCustomAttribute<UrlSegmentAttribute>(true);
                var urlTerminator = prop.GetCustomAttribute<UrlTerminatorAttribute>(true);

                if (urlSegment == null)
                    continue;

                var segment = new UrlSegmentInfo
                {
                    Order = urlSegment.NullableOrder,
                    Name = urlSegment.SegmentName,
                    Value = GetSegmentValue(prop, request),
                    IsTerminator = urlTerminator != null
                };

                if (segment.Value == null && !segment.IsTerminator)
                    continue;

                segments.Add(segment);
            }

            if (segments.Count(x => x.IsTerminator) > 1)
                throw new Exception("A request can only have one property with the UrlTerminator attribute");

            segments.Sort();

            return segments;
        }

        private static string GetSegmentValue(PropertyInfo property, IErgastRequest request)
        {
            var value = property.GetValue(request);
            if (value?.GetType().GetTypeInfo().IsEnum == true)
                value = (int) value;

            return value?.ToString();
        }
    }
}
