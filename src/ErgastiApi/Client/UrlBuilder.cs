using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ErgastApi.Client.Attributes;
using ErgastApi.Requests;

namespace ErgastApi.Client
{
    public class UrlBuilder : IUrlBuilder
    {
        // TODO: Refactor/cleanup
        public string Build(IErgastRequest request)
        {
            // TODO: Refactor to check for UrlSegmentDependencyAttribute and that the dependent property value is not null

            var calls = new List<UrlSegmentInfo>();
            UrlSegmentInfo lastCall = null;
            var properties = request.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var prop in properties)
            {
                var queryMethod = prop.GetCustomAttributes<UrlSegmentAttribute>(true).FirstOrDefault();
                var queryTerminator = prop.GetCustomAttributes<UrlTerminatorAttribute>(true).FirstOrDefault();

                if (queryMethod == null)
                    continue;

                // TODO: Expand UrlSegmentInfo with more info like PropertyInfo etc.
                var call = new UrlSegmentInfo
                {
                    Name = queryMethod.MethodName,
                    Order = queryMethod.Order,
                    Value = prop.GetValue(request)?.ToString(),
                    IsTerminator = queryTerminator != null
                };

                if (call.IsTerminator)
                {
                    lastCall = call;
                }
                else
                {
                    calls.Add(call);
                }
            }

            // TODO: Sort by order value first, then alphabetically
            calls.Sort();

            if (lastCall != null)
            {
                calls.Add(lastCall);
            }

            var output = "";
            foreach (var call in calls)
            {
                if (call.Value != null || call.IsTerminator)
                {
                    if (call.Name != null)
                        output += $"/{call.Name}";

                    if (call.Value != null)
                        output += $"/{call.Value}";
                }
            }

            output += ".json";

            if (request.Limit != null)
                output += "?limit=" + request.Limit;

            if (request.Offset != null)
            {
                output += request.Limit == null ? "?" : "&";
                output += "offset=" + request.Offset;
            }

            return output;
        }
    }
}
