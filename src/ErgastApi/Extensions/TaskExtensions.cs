using System;
using System.Linq;
using System.Threading.Tasks;

namespace ErgastApi.Extensions
{
    internal static class TaskExtensions
    {
        public static void WaitSafely(this Task task)
        {
            try
            {
                task?.Wait();
            }
            catch (AggregateException ex)
            {
                // Ignore TaskCanceledException
                if (!ex.InnerExceptions.OfType<TaskCanceledException>().Any())
                {
                    throw;
                }
            }
        }
    }
}
