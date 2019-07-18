using System;
using ErgastApi.Requests;
using ErgastApi.Responses;

namespace ErgastApi.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an <see cref="ErgastRequest{TResponse}"/> is invalid,
    /// usually by combining filters that are not supported together.
    /// </summary>
    public class ErgastInvalidRequestException : Exception
    {
        public ErgastInvalidRequestException(string message)
            : base(message)
        {

        }

        public ErgastInvalidRequestException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public static ErgastInvalidRequestException InvalidStandingsRequest(string invalidPropertyName)
        {
            var message =
                $"{invalidPropertyName} cannot be combined with circuit, grid, result or status qualifiers:" +
                $"\n\t{nameof(StandardRequest<ErgastResponse>.CircuitId)}" +
                $"\n\t{nameof(StandardRequest<ErgastResponse>.FastestLapRank)}" +
                $"\n\t{nameof(StandardRequest<ErgastResponse>.FinishingPosition)}" +
                $"\n\t{nameof(StandardRequest<ErgastResponse>.FinishingStatus)}" +
                $"\n\t{nameof(StandardRequest<ErgastResponse>.StartingPosition)}";

            return new ErgastInvalidRequestException(message);
        }
    }
}
