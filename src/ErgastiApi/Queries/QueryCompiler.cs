using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ErgastApi.Queries.Default.Info;

namespace ErgastApi.Queries
{
    public class QueryCompiler : IQueryCompiler
    {
        // TODO: Refactor/cleanup
        public string Compile(IQuery query)
        {
            var calls = new List<MethodCall>();
            MethodCall lastCall = null;
            var properties = typeof(DriverInfoQuery).GetProperties();
            foreach (var prop in properties)
            {
                var queryMethod = prop.GetCustomAttribute<QueryMethodAttribute>();
                var queryTerminator = prop.GetCustomAttribute<QueryTerminatorAttribute>();

                if (queryTerminator != null)
                {
                    lastCall = new MethodCall { Name = queryMethod.MethodName, Order = queryMethod.Order, IsTerminator = true, Value = prop.GetValue(query)?.ToString() };
                    continue;
                }

                calls.Add(new MethodCall { Name = queryMethod.MethodName, Order = queryMethod.Order, IsTerminator = false, Value = prop.GetValue(query)?.ToString() });
            }

            calls.Sort();

            calls.Add(lastCall);

            var output = "";
            foreach (var call in calls)
            {
                if (call.Value != null || call.IsTerminator)
                {
                    if (call.Name != null)
                        output += $"/{call.Name}";
                    output += $"/{call.Value}";
                }
            }

            return output;
        }
    }
}
