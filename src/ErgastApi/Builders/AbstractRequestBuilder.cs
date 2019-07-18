using ErgastApi.Requests;

namespace ErgastApi.Builders
{
    public abstract class AbstractRequestBuilder<TBuilder, TRequest> : IRequestBuilder<TRequest>
        where TBuilder : class
        where TRequest : class, IErgastRequest, new()
    {
        public TRequest Request { get; }

        protected AbstractRequestBuilder()
        {
            Request = new TRequest();
        }

        protected AbstractRequestBuilder(TRequest request)
        {
            Request = request;
        }

        public TBuilder Season(string season)
        {
            Request.Season = season;
            return this as TBuilder;
        }

        public TBuilder Round(string round)
        {
            Request.Round = round;
            return this as TBuilder;
        }

        public TBuilder Season(int season) => Season(season.ToString());

        public TBuilder Round(int round) => Round(round.ToString());

        public TBuilder Offset(int? offset)
        {
            Request.Offset = offset;
            return this as TBuilder;
        }

        public TBuilder Limit(int? limit)
        {
            Request.Limit = limit;
            return this as TBuilder;
        }

        public TBuilder Page(int page, int pageSize)
        {
            Request.Page(page, pageSize);
            return this as TBuilder;
        }
    }
}