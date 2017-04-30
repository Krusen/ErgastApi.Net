namespace ErgastApi.Queries
{
    public interface IQuery
    {
        int? Limit { get; set; }

        int? Offset { get; set; }

        int? Season { get; set; }

        int? Round { get; set; }

        string DriverId { get; set; }

        // TODO: Move to extension method to allow returning TQuery?
        void Page(int page, int pageSize);
    }
}