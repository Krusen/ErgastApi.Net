using ErgastApi.Requests;
using ErgastApi.Responses;
using ErgastApi.Responses.Models;

namespace ErgastApi.Builders
{
    public abstract class StandardRequestBuilder<TBuilder, TRequest, TResponse> : AbstractRequestBuilder<TBuilder, TRequest>
        where TBuilder : class
        where TRequest : StandardRequest<TResponse>, new()
        where TResponse : ErgastResponse
    {
        protected StandardRequestBuilder()
        {
        }

        protected StandardRequestBuilder(TRequest request)
            : base(request)
        {
        }

        public TBuilder Circuit(string circuitId)
        {
            Request.CircuitId = circuitId;
            return this as TBuilder;
        }

        public TBuilder Driver(string driverId)
        {
            Request.DriverId = driverId;
            return this as TBuilder;
        }

        public TBuilder Constructor(string constructorId)
        {
            Request.ConstructorId = constructorId;
            return this as TBuilder;
        }

        public TBuilder FastestLapRank(int? rank)
        {
            Request.FastestLapRank = rank;
            return this as TBuilder;
        }

        public TBuilder FinishingPosition(int? position)
        {
            Request.FinishingPosition = position;
            return this as TBuilder;
        }

        public TBuilder FinishingStatus(FinishingStatusId? status)
        {
            Request.FinishingStatus = status;
            return this as TBuilder;
        }

        public TBuilder StartingPosition(int? position)
        {
            Request.StartingPosition = position;
            return this as TBuilder;
        }
    }
}