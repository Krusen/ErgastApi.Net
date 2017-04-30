using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ErgastApi.Queries
{
    public class QueryCompiler : IQueryCompiler
    {
        // TODO: Refactor/cleanup
        public string Compile(IQuery query)
        {
            // TODO: Refactor to check for QueryDependencyAttribute and that the dependent property value is not null

            var calls = new List<MethodCall>();
            MethodCall lastCall = null;
            var properties = query.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var prop in properties)
            {
                var queryMethod = prop.GetCustomAttributes<QueryMethodAttribute>(true).FirstOrDefault();
                var queryTerminator = prop.GetCustomAttributes<QueryTerminatorAttribute>(true).FirstOrDefault();

                if (queryMethod == null)
                    continue;

                // TODO: Expand MethodCall with more info like PropertyInfo etc.
                var call = new MethodCall
                {
                    Name = queryMethod.MethodName,
                    Order = queryMethod.Order,
                    Value = prop.GetValue(query)?.ToString(),
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

            return output;
        }
    }
}
